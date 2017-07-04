using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Pololu.UsbWrapper;
using Pololu.SimpleMotorController;
using System.Text;
using System.ComponentModel;
using System.Windows.Forms;

namespace ChickenCoop
{
    public partial class door : System.Web.UI.Page
    {
        public string Text { get; private set; }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnOpen_Click(object sender, EventArgs e)
        {
            try
            {
                using (Smc device = connectToDevice())  // Find a device and temporarily connect.
                {
                    device.resume();         // Clear as many errors as possible.
                    device.setSpeed(3200);   // Set the speed to full forward (+100%).
                }
            }
            catch (Exception exception)  // Handle exceptions by displaying them to the user.
            {
                displayException(exception);
            }

            lblDoorStatus.Text = "Door Open...";
        }

        protected void btnClose_Click(object sender, EventArgs e)
        {

            try
            {
                using (Smc device = connectToDevice())  // Find a device and temporarily connect.
                {
                    device.resume();          // Clear as many errors as possible.
                    device.setSpeed(-3200);   // Set the speed to full reverse (-100%).
                }
            }
            catch (Exception exception)  // Handle exceptions by displaying them to the user.
            {
                displayException(exception);
            }

            lblDoorStatus.Text = "Door Close...";

        }


        Smc connectToDevice()
        {
            // Get a list of all connected devices of this type.
            List<DeviceListItem> connectedDevices = Smc.getConnectedDevices();

            foreach (DeviceListItem dli in connectedDevices)
            {
                // If you have multiple devices connected and want to select a particular
                // device by serial number, you could simply add a line like this:
                //   if (dli.serialNumber != "39FF-7406-3054-3036-4923-0743"){ continue; }

                Smc device = new Smc(dli); // Connect to the device.
                return device;             // Return the device.
            }
            throw new Exception("Could not find device.  Make sure it is plugged in to USB " +
                "and check your Device Manager (Windows) or run lsusb (Linux).");
        }

        /// <summary>
        /// Displays an exception to the user by popping up a message box.
        /// </summary>
        public void displayException(Exception exception)
        {
            StringBuilder stringBuilder = new StringBuilder();
            do
            {
                stringBuilder.Append(exception.Message + "  ");

                if (exception is Win32Exception)
                {
                    stringBuilder.Append("Error code 0x" + ((Win32Exception)exception).NativeErrorCode.ToString("x") + ".  ");
                }

                exception = exception.InnerException;
            }
            while (exception != null);
            MessageBox.Show(stringBuilder.ToString(), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}