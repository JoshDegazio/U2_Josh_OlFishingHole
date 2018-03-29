/*Josh Degazio
 * March 28, 2018
 * Program that calculates options for catching fish based on the values entered.
 * */
 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace U2_Josh_FishingHole
{
    // Creates a class for variables which can be called on later.
    public static class Globals
    {
        public static bool TroutPointsValid; //x
        public static bool WalleyePointsValid; //y
        public static bool PikePointsValid; //z
        public static bool TrWaPoValid; //xy
        public static bool WaPiPoValid; //yz
        public static bool TrWaPiPoValid; //xyz
        public static string[] InputSplit = new string[4];
        public static string InputText;
        public static int TroutPoints;
        public static int WalleyePoints;
        public static int PikePoints;
        public static int TotalPoints;
        public static int WaysToCatch = 0;
    }

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
        }

        //When clicked, runs program.
        public void Click_Run(object Sender, RoutedEventArgs e)
        {
            //Calls upon methods
            ResetProgram();
            InputValuesToVariables();
            ValidateValues();
            GenerateLines();
        }

        //Sets input values to integers so they can be read by the computer.
        private void InputValuesToVariables()
        {
            //Removes "\r" from the input text.
            Globals.InputText = txt_input.Text.Replace("\r", "");
            //Splits input text at "\r" and removes it.
            Globals.InputSplit = Globals.InputText.Split('\n');
            //Sets input values
            int.TryParse(Globals.InputSplit[0], out Globals.TroutPoints);
            int.TryParse(Globals.InputSplit[1], out Globals.WalleyePoints);
            int.TryParse(Globals.InputSplit[2], out Globals.PikePoints);
            int.TryParse(Globals.InputSplit[3], out Globals.TotalPoints);
        }

        //Sets bools to true or false.
        private void ValidateValues()
        {
            //x
            if (Globals.TroutPoints <= Globals.TotalPoints) {Globals.TroutPointsValid = true;}
            else { Globals.TroutPointsValid = false;}

            //y
            if (Globals.WalleyePoints <= Globals.TotalPoints) {Globals.WalleyePointsValid = true;}
            else { Globals.WalleyePointsValid = false;}

            //z
            if (Globals.PikePoints <= Globals.TotalPoints) {Globals.PikePointsValid = true;}
            else { Globals.PikePointsValid = false;}

            //xy
            if ((Globals.TroutPoints + Globals.WalleyePoints) <= Globals.TotalPoints) { Globals.TrWaPoValid = true; }
            else { Globals.TrWaPoValid = false; }

            //yz
            if ((Globals.WalleyePoints + Globals.PikePoints) <= Globals.TotalPoints) { Globals.WaPiPoValid = true; }
            else { Globals.WaPiPoValid = false; }

            //xyz
            if ((Globals.TroutPoints + Globals.WalleyePoints + Globals.PikePoints) <= Globals.TotalPoints) { Globals.TrWaPiPoValid = true; }
            else { Globals.TrWaPiPoValid = false; }
        }

        //Generates output.
        private void GenerateLines()
        {
            RunLogic();
            txt_outpt.Text = txt_outpt.Text + "Number of ways to catch fish: " + Globals.WaysToCatch;
        }

        //Resets program
        private void ResetProgram()
        {
            //Resets output text.
            txt_outpt.Text = "";
            //Resets ways to catch integer
            Globals.WaysToCatch = 0;
        }

        //Runs logic behind program, and generates several output lines.
        private void RunLogic()
        {
            //Checks if trout are worth less than the total amount of points allowed.
            if (Globals.TroutPointsValid == true)
            {
                //x
                //Countsdown the amount of trout available to catch.
                for (int i = (Globals.TotalPoints/Globals.TroutPoints); i > 0; i--)
                {
                    //Outputs the amount of trout that can be caught based upon value of i.
                    txt_outpt.Text = txt_outpt.Text + "Brown Trout: " + i + ", Walleye: 0, Pike: 0\n";
                    //Adds to the ways to catch integer.
                    Globals.WaysToCatch = Globals.WaysToCatch + 1;
                }
            }

            if (Globals.WalleyePointsValid == true)
            {
                //y
                for (int i = (Globals.TotalPoints / Globals.WalleyePoints); i > 0; i--)
                {
                    txt_outpt.Text = txt_outpt.Text + "Brown Trout: 0, Walleye: " + i + ", Pike: 0\n";
                    Globals.WaysToCatch = Globals.WaysToCatch + 1;
                }
            }

            if (Globals.PikePointsValid == true)
            {
                //z
                for (int i = (Globals.TotalPoints / Globals.PikePoints); i > 0; i--)
                {
                    txt_outpt.Text = txt_outpt.Text + "Brown Trout: 0, Walleye: 0, Pike: " + i + "\n";
                    Globals.WaysToCatch = Globals.WaysToCatch + 1;
                }
            }

            //Checks if trout and walleye can be caught and still have less than or equal to, totalpoints.
            if (Globals.TrWaPoValid == true)
            {
                //xy
                //Countsdown the amount of trout and walleye that can be caught.
                for (int i = (Globals.TotalPoints / (Globals.TroutPoints + Globals.WalleyePoints)); i > 0; i--)
                {
                    //Outputs the amount of trout and walleye that can be caught based on the value of i.
                    txt_outpt.Text = txt_outpt.Text + "Brown Trout: " + i + ", Walleye: " + i + ", Pike: 0\n";
                    //Adds to the ways to catch integer.
                    Globals.WaysToCatch = Globals.WaysToCatch + 1;
                }
            }

            if (Globals.WaPiPoValid == true)
            {
                //yz
                for (int i = (Globals.TotalPoints / (Globals.WalleyePoints + Globals.PikePoints)); i > 0; i--)
                {
                    txt_outpt.Text = txt_outpt.Text + "Brown Trout: 0, Walleye: " + i + ", Pike: " + i + "\n";
                    Globals.WaysToCatch = Globals.WaysToCatch + 1;
                }
            }

            //Checks if trout, walleye, and pike can be caught and still have less than or equal to, totalpoints.
            if (Globals.TrWaPiPoValid == true)
            {
                //xyz
                //Countsdown the amount of trout, walleye, and pike, that can be caught.
                for (int i = (Globals.TotalPoints / (Globals.TroutPoints + Globals.WalleyePoints + Globals.PikePoints)); i > 0; i--)
                {
                    //Outputs the amount of trout, walleye, and pike that can be caught based on the value of i.
                    txt_outpt.Text = txt_outpt.Text + "Brown Trout: " + i + ", Walleye: " + i + ", Pike: " + i + "\n";
                    //Adds to the ways to catch integer
                    Globals.WaysToCatch = Globals.WaysToCatch + 1;
                }
            }
        }
    }
}
