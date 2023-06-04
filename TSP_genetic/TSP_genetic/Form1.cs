using System.Text;

namespace TSP_genetic
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void start_Click(object sender, EventArgs e)
        {

            string solutionDirectory = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            string filePath = Path.Combine(solutionDirectory, "paczkomaty.txt");
            Packmat paczkomat = new Packmat();

            textBox1.AppendText(paczkomat.LoadConnectionsFromFile(filePath) + Environment.NewLine);

            textBox1.AppendText("Numery paczkomatu: ");
            // Przyk³ad u¿ycia: wyœwietlenie numerów paczkomatów i ich po³¹czeñ
            foreach (string packmanNo in paczkomat.allPackmatNumbers)
            {
                textBox1.AppendText(" " + packmanNo + " ");
            }
            textBox1.AppendText(Environment.NewLine);
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
    }
}
