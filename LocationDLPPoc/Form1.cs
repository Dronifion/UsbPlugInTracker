using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Security;
using System.Security.Cryptography;
//using System.Media;
using System.Management;

namespace LocationDLPPoc
{
    public partial class Form1 : Form
    {
        private static byte[] key;
        private static byte[] IV;
        private static Random random = new Random();

        public Form1()
        {
            InitializeComponent();
        }

        private void btnSetPolicy_Click(object sender, EventArgs e)
        {
            if ((txtSSID.Text == "") || (txtFilename.Text == ""))
            {
                MessageBox.Show("Please enter the USB disk drive's Signature and its Model");
            }
            else
            {
                //Step1
                txtFilename.Enabled = false;
                txtSSID.Enabled = false;
                btnSearchUSB.Enabled = false;

                //Step2
                btnSetPolicy.Enabled = false;
                btnCancelPolicy.Enabled = true;

                //Timer
                tmrMonitor.Enabled = true;           

            };

        }
        private void btnCancelPolicy_Click(object sender, EventArgs e)
        {
            //Step 1
            txtSSID.Enabled = true;
            txtFilename.Enabled = true;
            btnSearchUSB.Enabled = true;

            //Step 2
            lbInfo.Items.Clear();
            lblStatus.Text = "";
            btnSetPolicy.Enabled = true;
            btnCancelPolicy.Enabled = false;

            //Timer
            tmrMonitor.Enabled = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string line;
            string skey;
            string sIV;

            //Step 2
            lblStatus.Text = "";
            btnCancelPolicy.Enabled = false;
            tmrMonitor.Interval = 1000;
            tmrMonitor.Enabled = false;

            //Cryptography
            RijndaelManaged myRijndael = new RijndaelManaged();
            
            //Create a new key and initialization vector.
            myRijndael.GenerateKey();
            myRijndael.GenerateIV();

            //Get the key and IV.
            key = myRijndael.Key;
            IV = myRijndael.IV;

            //keep the keys into file
            try
            {
                if (File.Exists(Application.StartupPath + "\\..\\key\\key.txt") == true)
                {
                    FileStream aFile = new FileStream(Application.StartupPath + "\\..\\key\\key.txt", FileMode.Open);
                    StreamReader sr = new StreamReader(aFile);

                    //Read line number 1 - key
                    line = sr.ReadLine(); //key
                    ConvertStringToByte(line, out key);

                    //Read line number 2 - IV
                    line = sr.ReadLine(); //IV
                    ConvertStringToByte(line, out IV);

                    sr.Close();
                    aFile.Close();
                    aFile.Dispose();
                }
                else
                {
                    //Write data onto key database
                    StreamWriter sw1 = File.CreateText(Application.StartupPath + "\\..\\key\\key.txt");

                    //Get the key and IV.
                    key = myRijndael.Key;
                    IV = myRijndael.IV;

                    //Write line number 1 - key
                    ConvertByteToString(key, out skey);
                    sw1.WriteLine(skey);

                    //Write line number 1 - IV
                    ConvertByteToString(IV, out sIV);
                    sw1.WriteLine(sIV);

                    sw1.Close();
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message, "Startup Error: ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private static void EncryptData(String inName, String outName, byte[] rijnKey, byte[] rijnIV)
        {
            try
            {
                //Create the file streams to handle the input and output files.
                FileStream fin = new FileStream(inName, FileMode.Open, FileAccess.Read);
                FileStream fout = new FileStream(outName, FileMode.OpenOrCreate, FileAccess.Write);
                fout.SetLength(0);

                //Create variables to help with read and write.
                byte[] bin = new byte[100]; //This is intermediate storage for the encryption.
                long rdlen = 0;              //This is the total number of bytes written.
                long totlen = fin.Length;    //This is the total length of the input file.
                int len;                     //This is the number of bytes to be written at a time.

                SymmetricAlgorithm rijn = SymmetricAlgorithm.Create(); //Creates the default implementation, which is RijndaelManaged.         
                CryptoStream encStream = new CryptoStream(fout, rijn.CreateEncryptor(rijnKey, rijnIV), CryptoStreamMode.Write);

                //Console.WriteLine("Encrypting...");

                //Read from the input file, then encrypt and write to the output file.
                while (rdlen < totlen)
                {
                    len = fin.Read(bin, 0, 100);
                    encStream.Write(bin, 0, len);
                    rdlen = rdlen + len;
                    //Console.WriteLine("{0} bytes processed", rdlen);
                }

                encStream.Close();
                fout.Close();
                fin.Close();
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private static void DecryptData(String inName, String outName, byte[] rijnKey, byte[] rijnIV)
        {
            try
            {
                //Create the file streams to handle the input and output files.            
                FileStream fin = new FileStream(inName, FileMode.Open, FileAccess.Read);
                FileStream fout = new FileStream(outName, FileMode.OpenOrCreate, FileAccess.Write);
                fout.SetLength(0);

                //Create variables to help with read and write.
                byte[] bin = new byte[100]; //This is intermediate storage for the decryption.
                long rdlen = 0;              //This is the total number of bytes written.
                long totlen = fin.Length;    //This is the total length of the input file.
                int len;                     //This is the number of bytes to be written at a time.

                SymmetricAlgorithm rijn = SymmetricAlgorithm.Create(); //Creates the default implementation, which is RijndaelManaged.         
                CryptoStream decStream = new CryptoStream(fout, rijn.CreateDecryptor(rijnKey, rijnIV), CryptoStreamMode.Write);

                //Console.WriteLine("Decrypting...");

                //Read from the input file, then encrypt and write to the output file.
                while (rdlen < totlen)
                {
                    len = fin.Read(bin, 0, 100);
                    decStream.Write(bin, 0, len);
                    rdlen = rdlen + len;
                    //Console.WriteLine("{0} bytes processed", rdlen);
                }

                decStream.Close();
                fout.Close();
                fin.Close();
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private static int CalculateRandomNumber(int min, int max)
        {
            return random.Next(min, max);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            EncryptDisk("USB Disk", "1223234", "F:", key, IV);
        }

        private static void EncryptDisk(String inDiskName, String inDiskSignature, String inDiskPath, 
            byte[] rijnKey, byte[] rijnIV)
        {
            string sHashText = "";
            string sHashResult = "";
            int iRandomMin = 0;
            int iRandomMax = 99999;
            int iRandomNumber = 0;
            string sDBPath = "";
            string sKey = "";
            string sIV = "";

            try
            {
                //Generate a random salt for the xml string
                iRandomNumber = CalculateRandomNumber(iRandomMin, iRandomMax);

                ConvertByteToString(key, out sKey);
                ConvertByteToString(IV, out sIV);

                //Compile the xml string for the hash
                sHashText = "<xml><diskName>" + inDiskName + "</diskName><diskSignature>" +
                    inDiskSignature + "</diskSignature><key>" + sKey + "</key><IV>" +
                    sIV + "</IV><salt>" + iRandomNumber + "</salt></xml>";

                //Generate the hash from the xml string
                sHashResult = CalculateSHA1(sHashText);


                //File encryption start here...
                FileInfo bFile = new FileInfo(inDiskPath + "\\token.txt");
                if (!bFile.Exists)
                {
                    //Keep the hash onto the software database
                    sDBPath = ".\\database.txt";
                    FileInfo aFile = new FileInfo(sDBPath);
                    if (!aFile.Exists)
                    {
                        //Write data onto database
                        StreamWriter sw1 = File.CreateText(sDBPath);
                        sw1.WriteLine(sHashText + "," + sHashResult);
                        sw1.Close();
                    }
                    else
                    {
                        //Append data onto database
                        StreamWriter sw1 = File.AppendText(sDBPath);
                        sw1.WriteLine(sHashText + "," + sHashResult);
                        sw1.Close();
                    }

                    //Write a token into the disk
                    FileStream fout2 = bFile.OpenWrite();
                    StreamWriter sw2 = new StreamWriter(fout2);
                    sw2.WriteLine(sHashResult);
                    sw2.Close();

                    //Search and encrypt all files in the directory
                    DirectoryInfo dir = new DirectoryInfo(inDiskPath + "\\");
                    foreach (FileInfo fi in dir.GetFiles())
                    {
                        if (fi.FullName != inDiskPath + "\\token.txt")
                        {
                            EncryptData(fi.FullName, fi.FullName + ".enc", key, IV);
                            fi.Delete();                            
                        }
                    }

                    //foreach (DirectoryInfo di in dir.GetDirectories())
                    //{
                    //    clearFolder(di.FullName);
                    //    di.Delete();
                    //}
                }   
                
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public static void ConvertStringToByte(string inString, out byte[] outBytes)
        {
            // string to byte[]
            outBytes = Encoding.Default.GetBytes(inString);
        }

        public static void ConvertByteToString(byte[] inBytes, out string outString)
        {
            // byte[] to string
            outString = Encoding.Default.GetString(inBytes);
        }

        /*** Encrypt a file: 
         * Encryption method allows file encryption so that only the account used to call 
         * this method can decrypt it. The Encrypt method requires exclusive access to the 
         * file being encrypted, and will fail if another process is using the file.
         * Both the Encrypt method and the Decrypt method use the cryptographic service provider (CSP) 
         * installed on the computer and the file encryption keys of the process calling the method.
         * The current file system must be formatted as NTFS and the current operating system must be 
         * Windows NT or later.
         ***/
        public static void AddAccountEncryption(string FileName)
        {
            try
            {
                File.Encrypt(FileName);
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /*** Decrypt a file: 
         * Encryption method allows file encryption so that only the account used to call 
         * this method can decrypt it. The Encrypt method requires exclusive access to the 
         * file being encrypted, and will fail if another process is using the file.
         * Both the Encrypt method and the Decrypt method use the cryptographic service provider (CSP) 
         * installed on the computer and the file encryption keys of the process calling the method.
         * The current file system must be formatted as NTFS and the current operating system must be 
         * Windows NT or later.
         ***/
        public static void RemoveAccountEncryption(string FileName)
        {
            try
            {
                File.Decrypt(FileName);
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private static string CalculateSHA1(string text)
        {
            //Need - using System.Security.Cryptography;
            Encoding enc = Encoding.ASCII;

            byte[] buffer = enc.GetBytes(text);
            SHA1CryptoServiceProvider cryptoTransformSHA1 = new SHA1CryptoServiceProvider();
            return BitConverter.ToString(cryptoTransformSHA1.ComputeHash(buffer)).Replace("-", "");
        }

        
        private void tmrMonitor_Tick(object sender, EventArgs e)
        {
            int iCount = 0;
            //string sInfo = "";
            string sSignature = "";
            string sModel = "";
            string sDiskDrive = "";

            lbInfo.Items.Clear();
            lblStatus.Text = "";

            try
            {
                //ManagementObjectSearcher searcher =
                    //new ManagementObjectSearcher("root\\CIMV2",
                    //    "SELECT * FROM Win32_DiskDrive");

                //new ManagementObjectSearcher("root\\CIMV2",
                //    "SELECT * FROM Win32_DiskDrive WHERE InterfaceType='USB'");

                //foreach (ManagementObject queryObj in searcher.Get())
                //{
                lbInfo.BeginUpdate();

                foreach (ManagementObject drive in new ManagementObjectSearcher(
                    "select * from Win32_DiskDrive where InterfaceType='USB'").Get())
                {

                    iCount = iCount + 1;
                    sSignature = Convert.ToString(drive["Signature"]);
                    sModel = Convert.ToString(drive["Model"]);

                    if ((sSignature == txtSSID.Text.Trim()) && (sModel == txtFilename.Text.Trim()))
                    {
                            lbInfo.Items.Add("-----------------------------------");
                            lbInfo.Items.Add("USB disk drive instance #" + Convert.ToString(iCount));
                            lbInfo.Items.Add("-----------------------------------");
                            lbInfo.Items.Add("With Model: " + sModel + " and Signature: " + sSignature + " is authorised.");
                            lbInfo.Items.Add("User may proceed using this disk drive");
                            lbInfo.Items.Add(" ");
                    }
                    else 
                    {
                        //if (lbMemSignature.Items.Contains(sSignature) == false)
                        //{
                        //    lbMemSignature.Items.Add(sSignature);
                        //lbInfo.Items.Add(" " + drive["Size"]);


                            lbInfo.Items.Add("-----------------------------------");
                            lbInfo.Items.Add("USB disk drive instance #" + Convert.ToString(iCount));
                            lbInfo.Items.Add("-----------------------------------");
                            lbInfo.Items.Add("With Model: " + sModel + " and Signature: " + sSignature + " is unauthorised.");

                            lblStatus.Text = "USB disk drive instance #" + Convert.ToString(iCount) 
                                + ", with Model: " + sModel + " and Signature: " + sSignature + " is unauthorised. "
                                + "All data in the disk drive will be encrypted. "
                                + "Please contact your system administrator to decrypt the data.";

                            // associate physical disks with partitions

                            foreach (ManagementObject partition in new ManagementObjectSearcher(
                                "ASSOCIATORS OF {Win32_DiskDrive.DeviceID='" + drive["DeviceID"]
                                  + "'} WHERE AssocClass = Win32_DiskDriveToDiskPartition").Get())
                            {
                                
                                lbInfo.Items.Add("With partition=" + partition["Name"]);

                                // associate partitions with logical disks (drive letter volumes)

                                foreach (ManagementObject disk in new ManagementObjectSearcher(
                                    "ASSOCIATORS OF {Win32_DiskPartition.DeviceID='"
                                      + partition["DeviceID"]
                                      + "'} WHERE AssocClass = Win32_LogicalDiskToPartition").Get())
                                {
                                    sDiskDrive = Convert.ToString(disk["Name"]);
                                    lbInfo.Items.Add("And at disk=" + sDiskDrive);
                                }
                            }

                            lbInfo.Items.Add("All data in the disk drive will be encrypted.");
                            lbInfo.Items.Add("Please contact your system administrator to decrypt the data.");

                            EncryptDisk(sModel, sSignature, sDiskDrive, key, IV);

                        //}
                            //All data in the unathrised USB disk drive will be encrypted
                            //Encryption code start here
                            //queryObj[
                            //ManagementObjectSearcher LogicalDisk =
                            //    new ManagementObjectSearcher("root\\CIMV2",
                            //    "SELECT * FROM Win32_LogicalDisk WHERE VolumeName='USB'"
                            //    + " AND Signature = '" + sSignature +"'"
                            //    + "
                            //    );
                                }
                }

                lbInfo.EndUpdate();
                //txtInfo.Text = sInfo;
            }
            catch (ManagementException Exc)
            {
                MessageBox.Show("An error occurred while querying for WMI data: " + Exc.Message);
            }

            /***********

            string output;
            string line;
            string sWlanConnectionStatus ="";
            string sWlanConnectedSSID = "";
            string sWlanConnectedBSSID = "";
            int iWlanConnectionStatus = 0;
            string sWlanAuthourisedSSID = "";

            //Cryptography
            //RijndaelManaged myRijndael = new RijndaelManaged();
            //byte[] fromEncrypt;
            //byte[] encrypted;
            //byte[] toEncrypt;
            //byte[] key;
            //byte[] IV;

            sWlanAuthourisedSSID = txtSSID.Text.Trim();
            
            //WLAN Interfaces Status
            Process proc = new Process();
            proc.StartInfo.CreateNoWindow = true;
            proc.StartInfo.FileName = "netsh";
            proc.StartInfo.Arguments = "wlan show interfaces mode=bssid";
            proc.StartInfo.RedirectStandardOutput = true;
            proc.StartInfo.UseShellExecute = false; // required for the Redirect setting above Process.Start(proc);
            proc.Start();
            output = proc.StandardOutput.ReadToEnd();
            proc.WaitForExit();

            txtInfo.Text = output;

            StringReader sr = new StringReader(output.ToString());
            line = null;
            

            while ((line = sr.ReadLine()) != null)
            {
                if (line.StartsWith("General Failure"))
                {
                    iWlanConnectionStatus = 0;
                    break;
                }
                if (line.StartsWith("    State"))
                {
                    iWlanConnectionStatus = 1; 
                    sWlanConnectionStatus = line.Substring(line.IndexOf(":") + 1).TrimStart(' ').TrimEnd(' ');
                    continue;
                }
                if (line.StartsWith("    SSID"))
                {
                    sWlanConnectedSSID = line.Substring(line.IndexOf(":") + 1).TrimStart(' ').TrimEnd(' ');
                    continue;
                }
                if (line.StartsWith("    BSSID"))
                {
                    sWlanConnectedBSSID = line.Substring(line.IndexOf(":") + 1).TrimStart(' ').TrimEnd(' ');
                    break;
                }
            }; //While loop

            if (iWlanConnectionStatus == 0)
            {
                lblStatus.Text = "Not connected. Action Taken: Sensitive data will be encrypted.";
                /*
                //Create a new key and initialization vector.
                myRijndael.GenerateKey();
                myRijndael.GenerateIV();

                //Get the key and IV.
                key = myRijndael.Key;
                IV = myRijndael.IV;
                 */
            /*
                EncryptData(lblFilename.Text, lblFilename.Text + ".enc", key, IV);

                DecryptData(lblFilename.Text + ".enc", lblFilename.Text + ".dec", key, IV);   
                
            }
            else 
            {
                if (sWlanAuthourisedSSID == sWlanConnectedSSID)
                { 
                    lblStatus.Text = "Connected to authourised SSID: " +sWlanConnectedSSID+ " with MAC Address: " +sWlanConnectedBSSID;
                }
                else 
                {
                    lblStatus.Text = "Connected to unauthourised SSID: " + sWlanConnectedSSID + " with MAC Address: " + sWlanConnectedBSSID
                        + ", Action Taken: Sensitive data will be encrypted.";

                    //Create a new key and initialization vector.
                    //myRijndael.GenerateKey();
                    //myRijndael.GenerateIV();

                    //Get the key and IV.
                    //key = myRijndael.Key;
                    //IV = myRijndael.IV;

                    EncryptData(lblFilename.Text, lblFilename.Text + ".enc", key, IV);

                    DecryptData(lblFilename.Text + ".enc", lblFilename.Text + ".dec", key, IV);   
                };
            };
             * */
        }

        private void btnSearchUSB_Click(object sender, EventArgs e)
        {
            int iCount = 0;
            string sInfo = "";

            try
            {
                foreach (ManagementObject drive in new ManagementObjectSearcher(
                    "select * from Win32_DiskDrive where InterfaceType='USB'").Get())
                {
                    iCount = iCount + 1;
                    sInfo = "-----------------------------------"
                    + "\n\r USB disk drive instance #" + Convert.ToString(iCount)
                    + "\n\r-----------------------------------"
                    + "\n\r Model: " + drive["Model"]
                    //+ "\n\r SerialNumber: " + queryObj["SerialNumber"]
                    + "\n\r Signature: " + drive["Signature"];
                    // associate physical disks with partitions

                    foreach (ManagementObject partition in new ManagementObjectSearcher(
                        "ASSOCIATORS OF {Win32_DiskDrive.DeviceID='" + drive["DeviceID"]
                          + "'} WHERE AssocClass = Win32_DiskDriveToDiskPartition").Get())
                    {
                        sInfo = sInfo + "\n\r Partition=" + partition["Name"];

                        // associate partitions with logical disks (drive letter volumes)

                        foreach (ManagementObject disk in new ManagementObjectSearcher(
                            "ASSOCIATORS OF {Win32_DiskPartition.DeviceID='"
                              + partition["DeviceID"]
                              + "'} WHERE AssocClass = Win32_LogicalDiskToPartition").Get())
                        {
                            sInfo = sInfo + "\n\r Disk=" + disk["Name"];
                        }
                    }
                    MessageBox.Show(sInfo);

                }
                if (sInfo == "")
                {
                    MessageBox.Show("No USB disk drive attached");
                }

            }
            catch (ManagementException Exc)
            {
                MessageBox.Show("An error occurred while querying for WMI data: " + Exc.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // browse all USB WMI physical disks

            foreach(ManagementObject drive in new ManagementObjectSearcher(
                "select * from Win32_DiskDrive where InterfaceType='USB' AND Signature='" + txtSSID.Text + "'").Get())
            {
                // associate physical disks with partitions

                foreach(ManagementObject partition in new ManagementObjectSearcher(
                    "ASSOCIATORS OF {Win32_DiskDrive.DeviceID='" + drive["DeviceID"]
                      + "'} WHERE AssocClass = Win32_DiskDriveToDiskPartition").Get())
                {
                    lb1.Items.Add("-----------------------");
                    lb1.Items.Add("Partition=" + partition["Name"]);

                    // associate partitions with logical disks (drive letter volumes)

                    foreach(ManagementObject disk in new ManagementObjectSearcher(
                        "ASSOCIATORS OF {Win32_DiskPartition.DeviceID='"
                          + partition["DeviceID"]
                          + "'} WHERE AssocClass = Win32_LogicalDiskToPartition").Get())
                    {
                        lb1.Items.Add("Disk=" + disk["Name"]);
                    }
                }

                // this may display nothing if the physical disk

                // does not have a hardware serial number

                lb1.Items.Add("Serial="
                 + new ManagementObject("Win32_PhysicalMedia.Tag='"
                 + drive["DeviceID"] + "'")["SerialNumber"]);


            }
        }



        
    }
}
