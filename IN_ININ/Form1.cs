using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using MySql.Data.MySqlClient;//libreria de mysql
using System.Data.SqlClient;


namespace Formulario
{
    public partial class Form1 : Form
    {
        string conexionSQL = "Server=localhost;port=3306;database=personas;Uid=root;pwd=Nala310804_;";
        public Form1()
        {
            InitializeComponent();
            textBoxNombre.TextChanged += ValidarNombre;
            textBoxApellidos.TextChanged += ValidarApellido;
            textBoxEdad.TextChanged += ValidarEdad;
            textBoxEstatura.TextChanged += ValidarEstatura;
            textBoxTelefono.TextChanged += ValidarTelefono;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void InsertarRegistro(string Nombres, string Apellidos, int Edad, decimal Estatura, string Telefono, string Genero)
        {
            using (MySqlConnection conection = new MySqlConnection(conexionSQL))
            {
                conection.Open();
                string insertQuery = "INSERT INTO personas1 (Nombre,Apellidos,Telefono,Estatura,Edad,Genero)" +
                "Values (@Nombre,@Apellidos,@Telefono,@Estatura,@Edad,@genero)";

                using (MySqlCommand command = new MySqlCommand(insertQuery, conection))
                {
                    command.Parameters.AddWithValue("@Nombre", Nombres);
                    command.Parameters.AddWithValue("@Apellidos", Apellidos);
                    command.Parameters.AddWithValue("@Telefono", Telefono);
                    command.Parameters.AddWithValue("@Estatura", Estatura);
                    command.Parameters.AddWithValue("@Edad", Edad);
                    command.Parameters.AddWithValue("@genero", Genero);
                    command.ExecuteNonQuery();
                }
                conection.Close();
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {

@@ -43,41 + 70,143 @@ private void button1_Click(object sender, EventArgs e)
        {
            Genero = "Mujer";
        }
        string datos = $"Nombres: {Nombres}\r\nApellidos: {Apellidos}\r\nTelefono: {Telefono} kg\r\nEstatura: {Estatura} cm\r\nEdad: {Edad} años\r\nGénero: {Genero}";
        string rutaArchivo = "C:/Users/OCHOA/Documents/datos";
        File.WriteAllText(rutaArchivo, datos);
            if (EsEnteroValido(Edad) && EsDecimalValido(Estatura) && EsEnteroValidoDe10Digitos(Telefono) && EsTextoValido(Nombres) && EsTextoValido(Apellidos))
            {
                string datos = $"Nombres: {Nombres}\r\nApellidos: {Apellidos} \r\nTelefono: {Telefono} kg\r\nEstatura:{Estatura} cm\r\nEdad:{Edad} años\r\nGenero: {Genero}";
        string ruta = "C:/Users/OCHOA/OneDrive/Documentos/prueba";
        //File.WriteAllText(ruta,datos);
        bool archivoExiste = File.Exists(ruta);
        Console.WriteLine(archivoExiste);
                if (archivoExiste == false)
                {
                    File.WriteAllText(ruta, datos);
                }
                else
                {
                    using (StreamWriter writer = new StreamWriter(ruta))
                    {
                        if (archivoExiste)
                        {
                            writer.WriteLine();
                            InsertarRegistro(Nombres, Apellidos, int.Parse(Edad), decimal.Parse(Estatura), Telefono, Genero);
    MessageBox.Show("Datos ingresados correctamente");


                        }
                        else
{
    writer.WriteLine(datos);
    InsertarRegistro(Nombres, Apellidos, int.Parse(Edad), decimal.Parse(Estatura), Telefono, Genero);
    MessageBox.Show("Datos ingresados correctamente");
}

                    }
                }
                MessageBox.Show("Datos guardados correctamente:\n\n" + datos, "informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
{
    MessageBox.Show("Datos no validos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
}

bool archivoExiste = File.Exists(rutaArchivo);
if (archivoExiste == false)
        }
        private bool EsEnteroValido(string valor)
{
    int resultado;
    return int.TryParse(valor, out resultado);
}
private bool EsDecimalValido(string valor)
{
    decimal resultado;
    return decimal.TryParse(valor, out resultado);
}
private bool EsEnteroValidoDe10Digitos(string input)
{
    if (input.Length != 10)
    {
        return false;

    }
    if (!input.All(char.IsDigit))
    {
        File.WriteAllText(rutaArchivo, datos);
        return false;
    }
    else
        return true;
}

private bool EsTextoValido(String valor)
{
    return System.Text.RegularExpressions.Regex.IsMatch(valor, @"^[a-zA-Z\s]+$");
}

private void ValidarTelefono(object sender, EventArgs e)
{
    TextBox textbox = (TextBox)sender;
    string input = textbox.Text;
    input = input.Replace(" ", "").Replace("-", "");
    if (input.Length > 10)
    {
        using (StreamWriter writer = new StreamWriter(rutaArchivo, true))
            if (!EsEnteroValidoDe10Digitos(input))
            {
                if (archivoExiste)
                {
                    writer.WriteLine();
                }
                writer.WriteLine(datos);
                MessageBox.Show("El telefono no es valido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textbox.Clear();
            }


    }
    else if (!EsEnteroValidoDe10Digitos(input))
    {
        MessageBox.Show("El telefono no es valido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
}





private void ValidarEstatura(object sender, EventArgs e)
{
    TextBox textbox = (TextBox)sender;
    if (!EsDecimalValido(textbox.Text))
    {
        MessageBox.Show("La estatura no es valida", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        textbox.Clear();
    }
}
private void ValidarEdad(object sender, EventArgs e)
{
    TextBox textbox = (TextBox)sender;
    if (!EsEnteroValido(textbox.Text))
    {
        MessageBox.Show("La edad no es valida", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        textbox.Clear();
    }
}
private void ValidarApellido(object sender, EventArgs e)
{
    TextBox textbox = (TextBox)sender;
    if (!EsTextoValido(textbox.Text))
    {
        MessageBox.Show("El apellido no es valido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        textbox.Clear();
    }
}
private void ValidarNombre(object sender, EventArgs e)
{
    TextBox textbox = (TextBox)sender;
    if (!EsTextoValido(textbox.Text))
    {
        MessageBox.Show("El nombre no es valido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        textbox.Clear();
    }
}





private void button2_Click(object sender, EventArgs e)
{
    textBoxNombre.Clear();
    textBoxApellidos.Clear();
    textBoxEstatura.Clear();
    textBoxTelefono.Clear();
    textBoxEdad.Clear();
    rbHombre.Checked = false;
    rbMujer.Checked = false;

}

    }
}