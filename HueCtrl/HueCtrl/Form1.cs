namespace HueCtrl
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            HueBridge hueBridge = new HueBridge("192.168.178.30");
            HueUser hueUser = new HueUser("UAh5fgfhDfukMra9aCKQMMmjnVmoO7kwELpn5Sjj", "EF4800D00368FF157068FF9E5069B888");

            hueBridge.getDevices(hueUser);
        }


    }
}