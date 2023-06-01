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
            List <Packmat> paczkomats = Packmat.LoadPackmatsFromFile(filePath);

            // Przyk�ad u�ycia: wy�wietlenie numer�w paczkomat�w i ich po��cze�
            foreach (Packmat paczkomat in paczkomats)
            {
                textBox1.AppendText("Numer paczkomatu: " + paczkomat.PackmatNumber + Environment.NewLine);
                textBox1.AppendText("Po��czenia: " + Environment.NewLine);
                foreach (Tuple<string,float> connection in paczkomat.Connections)
                {
                    textBox1.AppendText(connection.Item1 +" "+ connection.Item2  + Environment.NewLine);
                }
                textBox1.AppendText(Environment.NewLine);
            }
        }
    }
}