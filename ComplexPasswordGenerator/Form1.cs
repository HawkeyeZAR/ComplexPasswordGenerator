using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ComplexPasswordGenerator
{
    public partial class FormPassword : Form
    {
        public FormPassword()
        {
            InitializeComponent();
        }

        private void buttonPassword_Click(object sender, EventArgs e)
        {
            string combinedCharSets = charSets();
            string password = randomizedString(combinedCharSets);
            textBoxPassword.Text = password;
            labelPasswordLength.Text = $"Password length: {password.Length} characters long";
        }

        // Takes the unsuffled string containing chars from each character set and shuffles them
        private string randomizedString(string l)
        {
            string unshuffled = l;
            Random num = new Random();

            // Create a new shuffled string from the unshuffled string
            //OrderBy(s => num.Next()).ToArray());
            string shuffled = new string(unshuffled.ToCharArray().
                OrderBy(s => num.Next()).ToArray());

            return shuffled;
        }

        private string charSets()
        {
            // Calls the randomNumber method of four character sets
            // returns a string containing a combination of the four sets.
            string[] charSet = new string[4] {
                "ABCDEFGHIJKLMNOPQRSTUVWXYZ",
                "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToLower(),
                "0123456789",
                @"~!@#$%^&*_-+=`|\(){}[]:;'<>,.?/"};
            // Set Uppercase limits: number chars needed, start position & stop postion for range
            int[] rangeU = new int[3] { 5, 0, 25 };
            // Set lowercase limits: number chars needed, start position & stop postion for range
            int[] rangeL = new int[3] { 5, 0, 25 };
            // Set digit limits: number chars needed, start position & stop postion for range
            int[] rangeN = new int[3] { 3, 0, 10 };
            // Set special character limits: number chars needed, start position & stop postion for range
            int[] rangeS = new int[3] { 3, 0, 31 };

            // calls randomNumber method
            // providing number chars needed, start position, stop position and char set to use
            string upper = randomNumber(rangeU[0], rangeU[1], rangeU[2], charSet[0]);
            string lower = randomNumber(rangeL[0], rangeL[1], rangeL[2], charSet[1]);
            string num = randomNumber(rangeN[0], rangeN[1], rangeN[2], charSet[2]);
            string spec = randomNumber(rangeS[0], rangeS[1], rangeS[2], charSet[3]);

            return upper + lower + num + spec;
        }

        // Generate random char strings
        // Medthod takes for params: range, start, stop and list
        private string randomNumber(int range, int start, int stop, string list)
        {
            string number = "";
            Random num = new Random();
            for (int i = 0; i < range; i++)
            {
                // get next random number and use as index for list
                int value = num.Next(start, stop);
                number += list[value];
            }
            return number;
        }
    }
}
