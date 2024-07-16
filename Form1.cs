using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.IO;
using System.Threading;
using System.Security.Cryptography;

namespace NetMonitor
{
    public partial class frmMain : Form
    {
        static string IPaddrFileNames = "";
        static string ResultsFolder = "";
        static bool checkingProcedure = true;

        public frmMain()
        {
            InitializeComponent();
        }

        private void cmdSelectFile_Click(object sender, EventArgs e)
        {
            try
            {
                // ΕΠΙΛΟΓΗ ΑΡΧΕΙΟΥ ΑΠΛΟΥ ΚΕΙΜΕΝΟΥ ΠΟΥ ΣΕ ΚΑΘΕ ΓΡΑΜΜΗ ΠΕΡΙΕΧΕΙ ΜΙΑ IP ΔΙΕΥΘΥΝΣΗ
                // ΔΗΛΑΔΗ ΠΧ 150 IP ΔΙΕΥΘΥΝΣΕΙΣ ΤΙΣ ΟΠΟΙΕΣ ΠΡΕΠΕΙ ΕΜΕΙΣ ΝΑ ΕΠΙΤΗΡΟΥΜΕ ΝΑ ΕΙΝΑΙ ΔΙΑΘΕΣΙΜΕΣ
                // Η ΚΑΘΕ ΜΙΑ ΣΕ ΚΑΘΕ ΓΡΑΜΜΗ ΑΡΑ ΑΠΛΟ ΑΡΧΕΙΟ ΚΕΙΜΕΝΟΥ 150 ΓΡΑΜΜΩΝ
                //openFileDialog1.RestoreDirectory = true;
                openFileDialog1.Title = "Επιλογή Αρχείου με IP Διευθύνσεις...";
                openFileDialog1.DefaultExt = "txt";
                openFileDialog1.Filter = "Αρχεία Κειμένου (*.txt)|*.txt|Όλα τα αρχεία (*.*)|*.*";

                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    IPaddrFileNames = openFileDialog1.FileName;
                }

                //MessageBox.Show(IPaddrFileNames);

            }
            catch (Exception ex)
            {
                Debug.Print(ex.Message);
            }
        }

        private void cmdSelectOutDir_Click(object sender, EventArgs e)
        {
            try
            {
                //ΕΠΙΛΟΓΗ ΜΟΝΟ ΤΟΥ ΦΑΚΕΛΟΥ ΟΠΟΥ ΓΡΑΦΟΝΤΑΙ ΤΑ LOG FILES ΜΕ ΤΑ ΑΠΟΤΕΛΕΣΜΑΤΑ ΤΗΣ PING IPCONFIG ΚΛΠ
                if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                {
                    ResultsFolder = folderBrowserDialog1.SelectedPath;
                }

                //MessageBox.Show(ResultsFolder);


            }
            catch (Exception ex)
            {
                Debug.Print(ex.Message);
            }
        }

        private void cmdStartChecking_Click(object sender, EventArgs e)
        {
            try
            {
                backgroundWorker1.RunWorkerAsync();

                // ΠΡΩΤΟ ΒΗΜΑ ΑΠΟ ΤΟ ΑΠΛΟ ΑΡΧΕΙΟ ΚΕΙΜΕΝΟΥ ΒΑΖΕΙ ΜΙΑ ΜΙΑ ΤΙΣ ΔΙΕΥΘΥΝΣΕΙΣ ΣΕ ΠΙΝΑΚΑ STRINGLIST
                // ΓΙΑ ΚΑΘΕ ΣΤΟΙΧΕΙΟ ΠΙΝΑΚΑ ΔΗΛΑΔΗ ΚΑΘΕ IP ADDRESS ΕΚΤΕΛΕΣΗ ΕΝΤΟΛΗΣ PING ΚΑΙ ΤΟ ΑΠΟΤΕΛΕΣΜΑ ΤΗΣ ΝΑ ΓΡΑΦΕΤΑΙ ΣΤΟ LOG FILE
                // ΔΗΛΑΔΗ MILLISECOND ΧΡΟΝΟΥ ΚΛΠ Η ΜΗ ΑΠΟΚΡΙΣΗ ΤΗΣ ΔΙΕΥΘΥΝΣΗΣ - ΤΕΛΟΣ ΑΝ ΚΑΠΟΙΑ ΔΙΕΥΘΥΝΣΗ ΕΙΝΑΙ OFF ΜΠΟΡΕΙ ΝΑ ΣΤΕΛΝΕΙ 
                // ΚΑΙ EMAIL ΕΝΗΜΕΡΩΤΙΚΟ ΣΕ ΜΙΑ ΔΙΕΥΘΥΝΣΗ ΔΙΑΧΕΙΡΙΣΤΗ
                // ΣΤΗ ΓΡΑΜΜΗ ΤΟΥ LOG FILE ΚΑΤΑΓΡΑΦΕΤΑΙ ΤΟ ΑΠΟΤΕΛΕΣΜΑ ΤΗΣ PING, IP ADRESS ΚΑΙ ΧΡΟΝΟΣΗΜΑΝΣΗ ΣΥΣΤΗΜΑΤΟΣ
                // ΥΠΑΡΧΕΙ ΧΡΟΝΟΚΑΘΥΣΤΕΡΗΣΗ (SLEEP - PAUSE) ΣΤΟ ΝΗΜΑ ΓΙΑ ΝΑ ΜΗΝ ΚΑΝΟΥΝ BAN ΤΗΝ ΕΦΑΡΜΟΓΗ ΤΑ ΕΠΙΜΕΡΟΥΣ FIREWALLS ΚΛΠ
                // ΤΟ LOG FILE ΠΑΙΡΝΕΙ ΟΝΟΜΑ ΧΡΟΝΟΣΗΜΑΝΣΗ ΚΑΙ ΤΗΝ ΚΑΤΑΛΗΞΗ ΠΧ TXT Η LOG ΔΗΛΑΔΗ ΠΧ 19-06-2024-11-30-35.TXT

                // ΑΦΟΥ ΕΧΕΙ ΓΡΑΦΤΕΙ ΤΟ ΠΡΩΤΟ LOG FILE ANAMENEI SLEEP ΤΟ ΛΟΓΙΣΜΙΚΟ ΠΧ 10 ΔΕΥΤΕΡΟΛΕΠΤΑ ΙΣΩΣ ΕΩΣ ΚΑΙ 10 ΛΕΠΤΑ
                // ΚΑΙ ΞΑΝΑΕΠΑΝΑΛΑΜΒΑΝΕΙ ΤΗ ΔΙΑΔΙΚΑΣΙΑ ΣΕ ΕΠΟΜΕΝΟ LOG FILE ΜΕ ΤΗΝ ΑΝΤΙΣΤΟΙΧΗ ΝΕΑ ΧΡΟΝΟΣΗΜΑΝΣΗ.

                // ΦΥΣΙΚΑ ΤΟ ΛΟΓΙΣΜΙΚΟ ΕΠΙΤΗΡΕΙ ΑΔΙΑΛΕΙΠΤΑ ΚΑΙ ΚΑΤΑΓΡΑΦΕΙ ΜΕ ΤΑ LOGS ΕΚΤΟΣ ΑΝ ΠΑΤΗΣΕΙ Ο ΧΡΗΣΤΗΣ ΕΞΟΔΟ
                // ΚΑΙ ΣΕ ΚΑΘΕ ΕΠΑΝΑΛΗΠΤΙΚΗ ΔΙΑΔΙΚΑΣΙΑ ΣΤΕΛΝΕΙ ΣΤΟΝ ΔΙΑΧΕΙΡΙΣΤΗ ΠΟΙΕΣ IP BRHKE DOWN ΚΑΙ ΤΗ ΧΡΟΝΙΚΗ ΣΤΙΓΜΗ. 
            }
            catch (Exception ex)
            {
                Debug.Print(ex.Message);
            }

        }

        private int RandomSeconds()
        // δημιουργει εναν ψευδοτυχαιο ακεραιο απο 100 εως και 9999
        {
            try { 

                var random = new Random();
                int res = random.Next(100, 10000); // αριθμός από 100 εως και 10000 millisecond
                return res;
            }
            catch (Exception ex)
            { 
                Debug.Print(ex.Message);
                return 1000;
            }


        }
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            while ( checkingProcedure == true)
            // αν δε πατησει exit ο χρηστης το συστημα καταγραφει συνεχως
            { 
                DataTable pingResults = new DataTable();


                pingResults.Clear();

                var logFile = File.ReadAllLines(IPaddrFileNames);
                // διαβασε τις IP διευθυνσεις

                var ipAddress = new List<string>(logFile);

                Parallel.For(0, ipAddress.Count(), (i, loopState) =>
                // κανε ασυγχρονο ελεγχο με την εντολη ping και καταγραψε τα αποτελεσματα
                {
                    Ping ping = new Ping();
                    PingReply pingReply = ping.Send(ipAddress[i].ToString());

                    this.BeginInvoke((Action)delegate ()
                    {
                    
                        if (pingReply.Status == IPStatus.Success)
                        {
                            // Εγγραφή στο Log File οτι η IP ειναι ΟΚ
                        }
                        else
                        { 
                            // Εγγραφή στο Log File οτι η IP δεν είναι ΟΚ και email σε διαχειριστή
                        }

                    });

                    Thread.Sleep(RandomSeconds());
                    // ΕΔΩ ΘΕΛΕΙ ΠΕΙΡΑΜΑΤΙΣΜΟ ΤΑ ΔΕΥΤΕΡΟΛΕΠΤΑ ΤΗΣ ΩΡΑΣ ΓΙΑ ΝΑ ΜΗΝ ΚΑΝΟΥΝ BAN ΤΑ FIREWALL ΤΟ APP

                    Application.DoEvents();

                });
                
            }


        }


        private void cmdExit_Click(object sender, EventArgs e)
        {
            // ΕΞΟΔΟΣ ΑΠΟ ΤΗΝ ΕΠΑΝΑΛΗΠΤΙΚΗ ΔΙΑΔΙΚΑΣΙΑ ΕΛΕΓΧΟΥ ΚΑΙ ΚΛΕΙΣΙΜΟ ΤΗΣ ΕΦΑΡΜΟΓΗΣ.

            checkingProcedure = false;

            Application.Exit();
        }
    }
}
