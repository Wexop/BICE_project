using BICE.DTO;
using BICE_Client;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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
using Materiel_DTO = BICE.DTO.Materiel_DTO;
using Vehicule_DTO = BICE_Client.Vehicule_DTO;

namespace BICE.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        Client client = new Client("https://localhost:7270", new System.Net.Http.HttpClient());

        private int findCategorieId(string categorieString)
        {

            var allCategorie = client.GetAll();

            int categorieID = 0;

            bool finded = false;

            foreach (var categorie in allCategorie)
            {
                if (categorie.Nom == categorieString)
                {
                    categorieID = categorie.Id_categorie;
                    finded = true;
                }
            }
       

            if (!finded)
            {
                var newCategorieDTO = new BICE_Client.Categorie_DTO()
                {
                    Nom = categorieString
                };

                client.Ajouter(newCategorieDTO);
                findCategorieId(categorieString);
            }

            return categorieID;
        }

        private void StockVehicule(object sender, RoutedEventArgs e)
        {
            TextBox immatriculation = FindName("ImmatriculationStock") as TextBox;
            if (client.GetById5(immatriculation.Text) == null) return;

            Microsoft.Win32.OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog();
            bool? result = openFileDialog.ShowDialog();

            if (result == true)
            {
                using (StreamReader reader = new StreamReader(openFileDialog.FileName))
                {
                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        var data = line.Split(';');

                        var materielID = data[0];

                        var materiel = client.GetById3(materielID);

                        if (materiel != null)
                        {

                            var materielDTO = new BICE_Client.Materiel_DTO()
                            {
                                CodeBarre = materiel.CodeBarre,
                                Categorie_ID = materiel.Categorie_ID,
                                Nb_utilisation = materiel.Nb_utilisation,
                                Nb_utilisation_max = materiel.Nb_utilisation_max,
                                Date_controle = materiel.Date_controle,
                                Date_peremption = materiel.Date_peremption,
                                Date_prochain_controle = materiel.Date_prochain_controle,
                                Stock = false,
                                Nom = materiel.Nom
                            };

                            client.Modifier3(materielDTO);

                        }

                    }

                }

            }

        }

        private void DeleteVehicule(object sender, RoutedEventArgs e)
        {
            TextBox immatriculation = FindName("ImmatriculationSupprimer") as TextBox;
            if (client.GetById5(immatriculation.Text) != null) client.Supprimer5(immatriculation.Text);
        }

        private void UpdateVehicule(object sender, RoutedEventArgs e)
        {
            TextBox immatriculation = FindName("ImmatriculationModifier") as TextBox;
            TextBox nom = FindName("NomModifier") as TextBox;
            TextBox numero = FindName("NumeroModifier") as TextBox;
            CheckBox utilisable = FindName("UtilisableModifier") as CheckBox;

            var vehiculeDTO = new BICE_Client.Vehicule_DTO()
            {
                Immatriculation = immatriculation.Text,
                Nom = nom.Text,
                Numero = int.Parse(numero.Text),
                Utilisable = utilisable.IsChecked?? true
            };

            client.Modifier5(vehiculeDTO);

        }

        private void InsertVehicule(object sender, RoutedEventArgs e)
        {
            TextBox immatriculation = FindName("Immatriculation") as TextBox;
            TextBox nom = FindName("Nom") as TextBox;
            TextBox numero = FindName("Numero") as TextBox;

            var vehiculeDTO = new Vehicule_DTO()
            {
                Immatriculation = immatriculation.Text,
                Nom = nom.Text,
                Numero = int.Parse(numero.Text),
                Utilisable = true
            };

            client.Ajouter5(vehiculeDTO);

        }

        private void InsertMaterielData(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog();
            bool? result = openFileDialog.ShowDialog();

            if (result == true)
            {
                using (StreamReader reader = new StreamReader(openFileDialog.FileName))
                {
                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        var data = line.Split(';');

                        var categorieID = findCategorieId(data[2]);

                        var dto = new BICE_Client.Materiel_DTO()
                        {
                            CodeBarre = data[0].ToString(),
                            Nom = data[1],
                            Categorie_ID = categorieID,
                            Nb_utilisation = String.IsNullOrEmpty(data[3]) ? null : int.Parse(data[3]),
                            Nb_utilisation_max = String.IsNullOrEmpty(data[4]) ? null : int.Parse(data[4]),
                            Date_peremption = data[5] == "" ? null : DateTime.Parse(data[5]),
                            Date_prochain_controle = data[6] == "" ? null : DateTime.Parse(data[6]),
                            Stock = true,
                            Date_controle = null,
                        };

                        Trace.WriteLine(dto.CodeBarre);

                        if (client.GetById3(dto.CodeBarre) == null ) client.Ajouter3(dto);
                        else client.Modifier3(dto);

                    }

                }

            }
        }

    }
}
