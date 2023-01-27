/**
 * Ardity (Serial Communication for Arduino + Unity)
 * Author: Daniel Wilches <dwilches@gmail.com>
 *
 * This work is released under the Creative Commons Attributions license.
 * https://creativecommons.org/licenses/by/2.0/
 */

using UnityEngine;
using System.Collections;
using System.Globalization;

/**
 * Sample for reading using polling by yourself. In case you are fond of that.
 */
public class SampleUserPolling_JustRead : MonoBehaviour
{
    public SerialController serialController;

    public float xValue = 0;
    public float yValue = 0;

    // Initialization
    void Start()
    {
        serialController = GameObject.Find("SerialController").GetComponent<SerialController>();
	}

    // Executed each frame
    void Update()
    {
        string message = serialController.ReadSerialMessage();

        if (message == null)
            return;

        // Check if the message is plain data or a connect/disconnect event.
        if (ReferenceEquals(message, SerialController.SERIAL_DEVICE_CONNECTED))
        {
            Debug.Log("Connection established");
            return;
        }
        else if (ReferenceEquals(message, SerialController.SERIAL_DEVICE_DISCONNECTED))
        {
            Debug.Log("Connection attempt failed or disconnection detected");
            return;
        }//else
         // Debug.Log("Message arrived: " + message);

        int indexOfDelimitor = message.IndexOf("|");
        string firstNumber = message.Substring(0, indexOfDelimitor);
        string secondNumber = message.Substring(indexOfDelimitor + 1);

        //firstNumber = firstNumber.Replace(".", ",");
        //secondNumber = secondNumber.Replace(".", ",");

        xValue = float.Parse(firstNumber, CultureInfo.InvariantCulture.NumberFormat);
        yValue = float.Parse(secondNumber, CultureInfo.InvariantCulture.NumberFormat);

    }
}
