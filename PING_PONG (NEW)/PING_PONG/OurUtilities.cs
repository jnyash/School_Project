using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace PING_PONG
{
  
    //MELLAN METODER----------------------------------------------------------------------

    public delegate void myEventHandler(string newValue);
    public class OurUtilities
    {

        //MELLAN METODER----------------------------------------------------------------------
        public static void imCleaningLabels(List<Label> delLabel)
        {
            //throw new NotImplementedException();
            foreach (Label item in delLabel)
            {
                item.Text = "";
            }
        }
        //MELLAN METODER----------------------------------------------------------------------

        public static string ssnSex(string sex)  //SAMIS!! KLAR!!! VISAR KÖN!
        {
            //// Denna koden ska flyttas till Main metod
            //string sex = "";  // Kön.. Man/kvinna..
            //Console.WriteLine(ssnSex(sex));

            // get the value of ssn without hyphen
            string ssn = OnlyNumbers(sex);

            if (verifyingSSNs(ssn) == "true")
            {
                if (OnlyNumbers(ssn).Length == 12)
                    ssn = ssn.Substring(2);
                if (OnlyNumbers(ssn).Length == 10)
                {
                    //string Pos9 = ssn.Substring(8, 1);

                    //// Two type of Array, one contains Even  Numbers and the other contains Odd Numbers
                    //string[] Even_Numbers = new string[] { "0", "2", "4", "6", "8" };   //Female
                    //string[] Odd_Numbers = new string[] { "1", "3", "5", "7", "9" };    //Male

                    //if (Even_Numbers.Contains(Pos9))
                    //    sex = "Mrs";
                    //else if (Odd_Numbers.Contains(Pos9))
                    //    sex = "Mr";

                    //Remake
                    int Pos99 = Convert.ToInt32(ssn.Substring(8, 1));
                    if (Pos99 % 2 == 0)
                        sex = "Mrs";
                    if (Pos99 % 2 != 0)
                        sex = "Mr";


                }
            }
            else
                sex = "MISTERBEEVER!";
            return sex;

            //SLUTET AV ssnSex!
        }

        //MELLAN METODER----------------------------------------------------------------------

        //public static string NumbersOnlynExtra(string Userin, string extra)
        //{
        //    string UserOuts = "";
        //    for (int i = 0; i < Userin.Length; i++)
        //    {
        //        // För varje tecken/siffra i Userin
        //        for (int ii = 0; ii < 10 + extra.Length; ii++)
        //        {
        //            // utförs en koll av varje siffra
        //            string temp = Userin.Substring(i, 1);

        //            if (temp == ii.ToString() && ii < 10)
        //            {
        //                //här kollar den om den har samma värde
        //                UserOuts = UserOuts + temp;
        //                //Console.WriteLine("Checkpoint 1: Sub: {0}, ii: {1}", temp, ii);
        //            }
        //            else if (extra != "" && 10 == ii)
        //            {
        //                for (int extraTecken = 0; extraTecken < extra.Length; extraTecken++)
        //                {
        //                    string extraExtra = extra.Substring(extraTecken, 1);
        //                    if (temp == extraExtra)
        //                    {
        //                        UserOuts = UserOuts + temp;

        //                        //Console.WriteLine("Checkpoint 2: ");
        //                    }
        //                }
        //            }
        //        }
        //    }
        //    return UserOuts;
        //}


        //MELLAN METODER----------------------------------------------------------------------


        public static string OnlynExtra(string Userin, string extra)
        {
            string UserOuts = "";
            //List<int> badIndex = new List<int>();
            for (int i = 0; i < Userin.Length; i++)
            {
                // För varje tecken/siffra i Userin
                //if (extra.IndexOf(Userin.Substring(i,1))
                //if (extra.IndexOf(Userin.Substring(i,1)) == null)
                //{
                //    badIndex.Add(i);
                //}
                // utförs en koll av varje siffra
                string temp = Userin.Substring(i, 1);

                for (int extraTecken = 0; extraTecken < extra.Length; extraTecken++)
                {
                    string extraExtra = extra.Substring(extraTecken, 1);
                    if (temp == extraExtra)
                    {
                        UserOuts += temp;

                        //Console.WriteLine("Checkpoint 2: ");
                    }
                    
                }
            }


            return UserOuts;
        }


        //MELLAN METODER----------------------------------------------------------------------

        public static string OnlyNumbers(string Userin)
        {
            return OnlynExtra(Userin, "0123456789");
        }

        //MELLAN METODER----------------------------------------------------------------------

        public static string OnlyEmail(string Userin)
        {
            return OnlynExtra(Userin, "1234567890qwertyuiopåäölkjhgfdsazxcvbnm.@-_QWERTYUIOPÅÄÖLKJHGFDSAZXCVBNM");
        }

        //MELLAN METODER-------------------------------------------------

        public static string OnlyLETTERS(string Userin)
        {
            return OnlynExtra(Userin, "-qwe rtyuiopåäölkjhgfdsazxcvbnmQWERTYUIOPÅÄÖLKJHGFDSAZXCVBNM");
        }


        //MELLAN METODER----------------------------------------------------------------------


        public static string OnlyLettNumb(string Userin)
        {
            return OnlynExtra(Userin, "-1234567890qwe rtyuiopåäölkjhgfdsazxcvbnmQWERTYUIOPÅÄÖLKJHGFDSAZXCVBNM");
        }


        //MELLAN METODER----------------------------------------------------------------------


        public static string verifyingSSNs(string ssnINC)
        {
            // Denna kan skicka tillbaka "true", "false", "bad", giltigt, ogiltigt, och icke ett personnummer.
            ssnINC = OnlyNumbers(ssnINC);
            int aaa = 0;        // denna har samma värde som i men vill använda denna i hela metoden.
            int summa = 0;      // Denna är först summan av hela skiten, men övergår till endast den sista viktiga siffran.
            string valid = "bad";         // Denna parameter är den som säger SSN är giltig eller inte.
            int[] numbers = new int[ssnINC.Length]; // Skapar en Array med antalet siffror i ssnINC alltså 10st.

            // Här börjar räkningen.. haha :)

            if (ssnINC.Length < 10)
            {
                //Console.WriteLine("Too Few charaters, to be a SSN, contains: {0} instead of 10", ssnINC.Length);
            }
            if (ssnINC.Length > 11 || ssnINC.Length == 12)
            {
                if (ssnINC.Substring(0, 1) == "1" || ssnINC.Substring(0, 1) == "2")
                {
                    ssnINC = ssnINC.Substring(2);
                }
                else
                {
                    //Console.WriteLine("Too many characters, to be a SSN, contains: {0} instead of 10", ssnINC.Length);
                }
            }
            if (ssnINC.Length == 10)
            {
                for (int i = 0; i < (ssnINC.Length); i++)
                {



                    // Jag fyller Array:en med värden INKLUSIVE sista siffran som kommer verifieras senare.
                    numbers[i] = Convert.ToInt32(ssnINC.Substring(i, 1));
                    //Console.WriteLine("Checkpoint 1: Tecken {0} har värdet {1}", i, numbers[i]);
                    if (numbers[2] == 0 || numbers[2] == 1 || numbers[4] == 0 || numbers[4] == 1 || numbers[4] == 2 || numbers[4] == 3)
                    {
                        //if (i == 0 || i == 2 || i == 4 || i == 6 || i == 8)
                        if (i % 2 == 0)
                        {
                            // Varnannat tecken skall dubblas, börjar med [0]
                            numbers[i] = numbers[i] * 2;
                            //Console.WriteLine("Checkpoint 2: Tecken {0} har värdet {1}", i, numbers[i]);

                            if (numbers[i] > 9)
                            {
                                // Om värdet är mer än 10 måste dessa tecken adderas ihop.
                                string convert = numbers[i].ToString();
                                numbers[i] = Convert.ToInt32(convert.Substring(0, 1)) + Convert.ToInt32(convert.Substring(1, 1));
                                //Console.WriteLine("Checkpoint 3: Tecken {0} har värdet {1}", i, numbers[i]);
                            }
                        }
                    }
                    else
                    {
                        break;
                    }
                    aaa = i;
                    if (i == (ssnINC.Length - 1))
                    {
                        // Jag vill inte ha med sista siffran i summa, och övar på break.
                        // kopierade från Checkpoint 3 och ändrat den.
                        //ville bara ha en IF sats :P FULLSTÄNDIGT ONÖDIG :P Men resten i denna del är viktig!!
                        string convert = summa.ToString();
                        //Console.WriteLine("Checkpoint 9: Tecken 0 är: {0}, och tecken 1 är: {1}", convert.Substring(0, 1), convert.Substring(1, 1));
                        //summa = 10-Convert.ToInt32(convert.Substring(1, 1)); bytte variabel för att behålla summan.
                        int kontrollsiffra = 10 - Convert.ToInt32(convert.Substring(1, 1));
                        //Console.WriteLine("Checkpoint 4: 10 - summans sista siffra({1})= {0}", convert.Substring(1, 1), kontrollsiffra);
                        int verify = Convert.ToInt32(ssnINC.Substring((aaa), 1));
                        //valid = true;

                        if ((kontrollsiffra) == verify)
                        {
                            //Console.WriteLine("Checkpoint 5: Rätt resultat! {0} vs {1}", kontrollsiffra, verify);
                            valid = "true";

                            //return valid; // fungerar EJ
                            //break;
                        }
                        else
                        {
                            //Console.WriteLine("Checkpoint 6: FEL resultat! {0} vs {1}", kontrollsiffra, verify);
                            valid = "false";
                            //return valid; // fungerar EJ
                            //break;
                        }
                        break; //när jag har return i if statsen ovan så klagar denna rad på att den är oåtkomlig.
                    }
                    else
                    {
                        // Här räknar den i hop summan, den hoppar alltså över sista siffran i person numret..
                        //Console.WriteLine("Checkpoint 8: tecken {0} har värde {1}", i, numbers[i]);
                        summa = summa + numbers[i];
                        //Console.WriteLine("Checkpoint 7: Summan hittils är: {0}", summa);
                    }
                }
            }
            return valid;  //denna fungerar ej, fast än jag satt värde på denna vid Checkpoint 5 && 6, samt skapade denna i början

            //SLUTET AV verifyingSSNs!!
        }

        //MELLAN METODER----------------------------------------------------------------------






        private string theValue;
        public event myEventHandler valueChanged;
        public string Val
        {
            set
            {
                this.theValue = value;
                this.valueChanged(theValue);
            }
        }








        public event EventHandler OnPropertyChanged;
        string name = "";
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged(this, new EventArgs());
            }
        }






        public static bool verifyingSSNs2(string ssnINC)
        {
            // Denna kan skicka tillbaka "true", "false", "bad", giltigt, ogiltigt, och icke ett personnummer.
            ssnINC = OnlyNumbers(ssnINC);
            int aaa = 0;        // denna har samma värde som i men vill använda denna i hela metoden.
            int summa = 0;      // Denna är först summan av hela skiten, men övergår till endast den sista viktiga siffran.
            bool valid = false;         // Denna parameter är den som säger SSN är giltig eller inte.
            int[] numbers = new int[ssnINC.Length]; // Skapar en Array med antalet siffror i ssnINC alltså 10st.

            // Här börjar räkningen.. haha :)

            if (ssnINC.Length < 10)
            {
                return valid;
                //Console.WriteLine("Too Few charaters, to be a SSN, contains: {0} instead of 10", ssnINC.Length);
            }
            if (ssnINC.Length > 10)
            {
                if (ssnINC.Length == 12)
                {
                    if (ssnINC.Substring(0, 1) == "1" || ssnINC.Substring(0, 1) == "2")
                    {
                        ssnINC = ssnINC.Substring(2);
                    }
                    else
                    {
                        return valid;
                        //Console.WriteLine("Too many characters, to be a SSN, contains: {0} instead of 10", ssnINC.Length);
                    }
                }
                else
                    return valid;
            }
            if (ssnINC.Length == 10)
            {
                for (int i = 0; i < (ssnINC.Length); i++)
                {



                    // Jag fyller Array:en med värden INKLUSIVE sista siffran som kommer verifieras senare.
                    numbers[i] = Convert.ToInt32(ssnINC.Substring(i, 1));
                    //Console.WriteLine("Checkpoint 1: Tecken {0} har värdet {1}", i, numbers[i]);
                    if (numbers[2] == 0 || numbers[2] == 1 || numbers[4] == 0 || numbers[4] == 1 || numbers[4] == 2 || numbers[4] == 3)
                    {
                        //if (i == 0 || i == 2 || i == 4 || i == 6 || i == 8)
                        if (i % 2 == 0)
                        {
                            // Varnannat tecken skall dubblas, börjar med [0]
                            numbers[i] = numbers[i] * 2;
                            //Console.WriteLine("Checkpoint 2: Tecken {0} har värdet {1}", i, numbers[i]);

                            if (numbers[i] > 9)
                            {
                                // Om värdet är mer än 10 måste dessa tecken adderas ihop.
                                string convert = numbers[i].ToString();
                                numbers[i] = Convert.ToInt32(convert.Substring(0, 1)) + Convert.ToInt32(convert.Substring(1, 1));
                                //Console.WriteLine("Checkpoint 3: Tecken {0} har värdet {1}", i, numbers[i]);
                            }
                        }
                    }
                    else
                    {
                        break;
                    }
                    aaa = i;
                    if (i == (ssnINC.Length - 1))
                    {
                        // Jag vill inte ha med sista siffran i summa, och övar på break.
                        // kopierade från Checkpoint 3 och ändrat den.
                        //ville bara ha en IF sats :P FULLSTÄNDIGT ONÖDIG :P Men resten i denna del är viktig!!
                        string convert = summa.ToString();
                        //Console.WriteLine("Checkpoint 9: Tecken 0 är: {0}, och tecken 1 är: {1}", convert.Substring(0, 1), convert.Substring(1, 1));
                        //summa = 10-Convert.ToInt32(convert.Substring(1, 1)); bytte variabel för att behålla summan.
                        int kontrollsiffra = 10 - Convert.ToInt32(convert.Substring(1, 1));
                        //Console.WriteLine("Checkpoint 4: 10 - summans sista siffra({1})= {0}", convert.Substring(1, 1), kontrollsiffra);
                        int verify = Convert.ToInt32(ssnINC.Substring((aaa), 1));
                        //valid = true;

                        if ((kontrollsiffra) == verify)
                        {
                            //Console.WriteLine("Checkpoint 5: Rätt resultat! {0} vs {1}", kontrollsiffra, verify);
                            valid = true;

                            //return valid; // fungerar EJ
                            //break;
                        }
                        else
                        {
                            //Console.WriteLine("Checkpoint 6: FEL resultat! {0} vs {1}", kontrollsiffra, verify);
                            valid = false;
                            //return valid; // fungerar EJ
                            //break;
                        }
                        break; //när jag har return i if statsen ovan så klagar denna rad på att den är oåtkomlig.
                    }
                    else
                    {
                        // Här räknar den i hop summan, den hoppar alltså över sista siffran i person numret..
                        //Console.WriteLine("Checkpoint 8: tecken {0} har värde {1}", i, numbers[i]);
                        summa = summa + numbers[i];
                        //Console.WriteLine("Checkpoint 7: Summan hittils är: {0}", summa);
                    }
                }
            }
            return valid;  //denna fungerar ej, fast än jag satt värde på denna vid Checkpoint 5 && 6, samt skapade denna i början

            //SLUTET AV verifyingSSNs!!
        }






    }
}