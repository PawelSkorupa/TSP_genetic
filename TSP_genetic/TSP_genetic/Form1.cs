using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace TSP_genetic
{
    public partial class Form1 : Form
    {
        public List<string> currentRoute = new List<string>();
        public Packmat paczkomat = new Packmat();
        public string filePath = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName, "paczkomaty.txt");
        public bool fileLoaded = false;
        public int popCount = 10;
        public int generationsCount = 10;
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void start_Click(object sender, EventArgs e)
        {
            if (!fileLoaded)
            {
                textBox1.AppendText("File not selected. Loading default file.");
                textBox1.AppendText(Environment.NewLine);
                textBox1.AppendText(paczkomat.LoadConnectionsFromFile(filePath));
                textBox1.AppendText(Environment.NewLine);
                fileLoaded= true;
                CreateCheckboxes(paczkomat.allPackmatNumbers);
            }
            if (currentRoute.Count > 2)
            {
                paczkomat.routePackmatNumbers = currentRoute;
                paczkomat.routePointsQuantity = currentRoute.Count;
                paczkomat.popSize = popCount;
                paczkomat.gen_thres = generationsCount;
                textBox1.AppendText("Packmat numbers: ");
                foreach (string packmanNo in paczkomat.allPackmatNumbers)
                {
                    textBox1.AppendText(" " + packmanNo + " ");
                }
                textBox1.AppendText(Environment.NewLine);
                textBox1.AppendText(Environment.NewLine);
                textBox1.AppendText("Population size: " + paczkomat.popSize.ToString());
                textBox1.AppendText(Environment.NewLine);

                int count = 0;
                for (int i = 0; i < paczkomat.connectionMatrix.GetLength(0); i++)
                {
                    for (int j = 0; j < paczkomat.connectionMatrix.GetLength(1); j++)
                    {
                        string value = paczkomat.connectionMatrix[i, j].ToString();
                        textBox1.AppendText(value.PadRight(5) + " ");
                        count++;
                        if (count == 20)
                        {
                            textBox1.AppendText(Environment.NewLine);
                            count = 0;
                        }
                    }
                }
                StringBuilder sb = paczkomat.TSPUtil(paczkomat.connectionMatrix);
                textBox1.AppendText(sb.ToString());
            }
            else if (fileLoaded)
            {
                textBox1.AppendText("You have selected too few packmats.");
                textBox1.AppendText(Environment.NewLine);
            }
            else
            {
                textBox1.AppendText("File wasn't loaded.");
                textBox1.AppendText(Environment.NewLine);
            }
        }
        void CreateCheckboxes(List<string> packmats)
        {
            flowLayoutPanel1.Controls.Clear();

            foreach (string paczkomat in packmats)
            {
                CheckBox checkBox = new CheckBox();
                checkBox.Text = paczkomat;
                checkBox.CheckedChanged += CheckBox_CheckedChanged;
                flowLayoutPanel1.Controls.Add(checkBox);
            }
            flowLayoutPanel1.AutoScroll = true;
        }

        private void CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;
            if (checkBox.Checked)
            {
                currentRoute.Add(checkBox.Text);
            }
            else
            {
                currentRoute.Remove(checkBox.Text);
            }
        }

        private void buttonLoad_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;

                textBox1.AppendText(paczkomat.LoadConnectionsFromFile(filePath));
                textBox1.AppendText(Environment.NewLine);
                CreateCheckboxes(paczkomat.allPackmatNumbers);
                fileLoaded = true;
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            popCount = Convert.ToInt32(numericUpDown1.Value);
        }

        private void selectAll_Click(object sender, EventArgs e)
        {
            if (flowLayoutPanel1.Controls.Count > 0)
            {
                foreach (Control control in flowLayoutPanel1.Controls)
                {
                    if (control is CheckBox checkBox)
                    {
                        checkBox.Checked = true;
                    }
                }
            }
        }

        private void deselectAll_Click(object sender, EventArgs e)
        {
            if (flowLayoutPanel1.Controls.Count > 0)
            {
                foreach (Control control in flowLayoutPanel1.Controls)
                {
                    if (control is CheckBox checkBox)
                    {
                        checkBox.Checked = false;
                    }
                }
            }
        }
        private void selectRandom_Click(object sender, EventArgs e)
        {
            if (flowLayoutPanel1.Controls.Count > 0)
            {
                Random random = new Random();

                int count = 5;
                int selectedCount = 0;
                foreach (Control control in flowLayoutPanel1.Controls)
                {
                    if (control is CheckBox checkBox)
                    {
                        if (random.NextDouble() < (double)count / (flowLayoutPanel1.Controls.Count - selectedCount))
                        {
                            checkBox.Checked = true;
                            selectedCount++;
                            count--;
                            if (count == 0)
                                break;
                        }
                    }
                }
            }
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            generationsCount = Convert.ToInt32(numericUpDown2.Value);
        }
    }
}

