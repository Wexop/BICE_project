using BICE.DTO;
using BICE_Client;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
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
using static System.Runtime.InteropServices.JavaScript.JSType;
using Materiel_DTO = BICE.DTO.Materiel_DTO;
using String = System.String;
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

        private void DestockMateriel(object sender, RoutedEventArgs e)
        {
            TextBox codeBarre = FindName("MaterielDestocker") as TextBox;

            if (codeBarre == null || client.GetById3(codeBarre.Text) == null) return;

            var materielDTO = client.GetById3(codeBarre.Text);
            materielDTO.Stock = false;
            client.Modifier3(materielDTO);
        }

        private void ExportUnstockedMateriel(object sender, RoutedEventArgs e)
        {
            TextBox directory = FindName("DirectoryPath") as TextBox;
            var streamWriter = new StreamWriter(directory.Text + "/materielPasStocker.csv");

            var materielList = (List<BICE_Client.Materiel_DTO>)client.GetAll3();

            if (materielList == null) return;

            string newLine = Environment.NewLine;

            //this acts as datarow
            foreach (var item in materielList)
            {

                if (!item.Stock)
                {
                    //this acts as datacolumn
                    var row = string.Join(";", new List<string>()
                    {
                        item.CodeBarre,
                        item.Nom,
                        item.Categorie_ID.ToString(),
                        item.Nb_utilisation?.ToString()?? "",
                        item.Nb_utilisation_max?.ToString()?? "",
                        item.Date_peremption?.ToString()?? "",
                        item.Date_prochain_controle?.ToString()?? "",
                        item.Vehicule_ID?.ToString()?? ""
                    });

                    if (row[0].ToString() != "" && row[1].ToString() != "" && row[2].ToString() != "") streamWriter.Write(row + newLine);
                };
            };

            streamWriter.Close();
        }       
        private void ExportControleMateriel(object sender, RoutedEventArgs e)
        {
            TextBox directory = FindName("DirectoryPath") as TextBox;
            var streamWriter = new StreamWriter(directory.Text + "/materielControle.csv");

            var materielList = (List<BICE_Client.Materiel_DTO>)client.GetAll3();

            if (materielList == null) return;

            string newLine = Environment.NewLine;

            //this acts as datarow
            foreach (var item in materielList)
            {

                if (item.Date_prochain_controle <= DateTime.Now)
                {
                    //this acts as datacolumn
                    var row = string.Join(";", new List<string>()
                    {
                        item.CodeBarre,
                        item.Nom,
                        item.Categorie_ID.ToString(),
                        item.Nb_utilisation?.ToString()?? "",
                        item.Nb_utilisation_max?.ToString()?? "",
                        item.Date_peremption?.ToString()?? "",
                        item.Date_prochain_controle?.ToString()?? "",
                        item.Vehicule_ID?.ToString()?? ""
                    });

                    if (row[0].ToString() != "" && row[1].ToString() != "" && row[2].ToString() != "") streamWriter.Write(row + newLine);
                };
            };

            streamWriter.Close();
        }

        private void ExportMaterielList(object sender, RoutedEventArgs e)
        {

            TextBox directory = FindName("DirectoryPath") as TextBox;
            var streamWriter = new StreamWriter(directory.Text + "/materielList.csv");

            var materielList = (List<BICE_Client.Materiel_DTO>) client.GetAll3();

            if (materielList == null) return;

            string newLine = Environment.NewLine;

            //this acts as datarow
            foreach (var item in materielList)
            {
                //this acts as datacolumn
                var row = string.Join(";",new List<string>()
                {
                    item.CodeBarre,
                    item.Nom,
                    item.Categorie_ID.ToString(),
                    item.Nb_utilisation?.ToString()?? "",
                    item.Nb_utilisation_max?.ToString()?? "",
                    item.Date_peremption?.ToString()?? "",
                    item.Date_prochain_controle?.ToString()?? "",
                    item.Vehicule_ID?.ToString()?? ""
                });

                if (row[0].ToString() != "" && row[1].ToString() != "" && row[2].ToString() != "") streamWriter.Write(row + newLine);

            };

            streamWriter.Close();

        }

        private void RetourIntervention(object sender, RoutedEventArgs e)
        {

            TextBox immatriculation = FindName("ImmatriculationInterventionRetour") as TextBox;
            if (immatriculation == null || client.GetById5(immatriculation.Text) == null) return;

            Microsoft.Win32.OpenFileDialog FileMaterielUtiliser = new Microsoft.Win32.OpenFileDialog();
            Microsoft.Win32.OpenFileDialog FileMaterielNonUtiliser = new Microsoft.Win32.OpenFileDialog();
            bool? result1 = FileMaterielUtiliser.ShowDialog();
            bool? result2 = FileMaterielNonUtiliser.ShowDialog();

            List<BICE_Client.Materiel_DTO> listMaterielUtiliser = new List<BICE_Client.Materiel_DTO>() { };
            List<BICE_Client.Materiel_DTO> listMaterielNonUtiliser = new List<BICE_Client.Materiel_DTO>() { };

            // materiel utilisé : utilisation += 1 && restockage en fonction des utilisations max + date peremption

            if (result1 == true)
            {
                using (StreamReader reader = new StreamReader(FileMaterielUtiliser.FileName))
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
                                Stock = materiel.Stock,
                                Nom = materiel.Nom,
                                Vehicule_ID = immatriculation.Text
                            };

                            listMaterielUtiliser.Add(materielDTO);
                            client.ModifierUtiliser(materielDTO);

                        }

                    }
                }
            }

            // materiel non utilisé : restocké

            if (result2 == true)
            {
                using (StreamReader reader = new StreamReader(FileMaterielNonUtiliser.FileName))
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
                                Stock = materiel.Stock,
                                Nom = materiel.Nom,
                                Vehicule_ID = immatriculation.Text
                            };

                            listMaterielNonUtiliser.Add(materielDTO);
                            client.Modifier3(materielDTO);

                        }

                    }
                }
            }

            // materiel perdu ?

            var materielInVehicule = new List<BICE_Client.Materiel_DTO>() { };

            foreach (var materiel in client.GetAll3())
            {
                if (materiel != null)
                {
                    if (materiel.Vehicule_ID != null && materiel.Vehicule_ID == immatriculation.Text) materielInVehicule.Add(materiel);
                }
            }

            var everyMaterielInFiles = new List<BICE_Client.Materiel_DTO>() { };
            everyMaterielInFiles.AddRange(listMaterielUtiliser);
            everyMaterielInFiles.AddRange(listMaterielNonUtiliser);

            var materielPerdu = new List<BICE_Client.Materiel_DTO>() { };

            foreach (var materiel in materielInVehicule)
            {
                var find = false;

                foreach (var m in everyMaterielInFiles)
                {
                    if (m.CodeBarre == materiel.CodeBarre) find = true;
                }

                if (!find) materielPerdu.Add(materiel);

            };

            // on destock les materiels perdus trouvé

            Trace.WriteLine("tab : " + materielInVehicule.Count());
            Trace.WriteLine("tab : " + everyMaterielInFiles.Count());
            Trace.WriteLine("tab : " + materielPerdu.Count());

            foreach (var mat in materielPerdu)
            {
                mat.Stock = false;
                client.Modifier3(mat);
            }

            // ajout intervention

            var interventionDTO = new BICE_Client.Intervention_DTO()
            {
                Date_intervention= DateTime.Now,
            };

            client.Ajouter2(interventionDTO);

        }

        private void StockVehicule(object sender, RoutedEventArgs e)
        {
            TextBox immatriculation = FindName("ImmatriculationStock") as TextBox;
            if (immatriculation == null || client.GetById5(immatriculation.Text) == null) return;

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
                                Stock = materiel.Stock,
                                Nom = materiel.Nom,
                                Vehicule_ID = immatriculation.Text
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

            if (immatriculation == null) return;
            var vehiculeDTO = client.GetById5(immatriculation.Text);


            if (vehiculeDTO != null)
            {
                vehiculeDTO.Utilisable = false;
                client.Modifier(vehiculeDTO.Immatriculation);
            }
        }

        private void UpdateVehicule(object sender, RoutedEventArgs e)
        {
            TextBox immatriculation = FindName("ImmatriculationModifier") as TextBox;
            TextBox nom = FindName("NomModifier") as TextBox;
            TextBox numero = FindName("NumeroModifier") as TextBox;
            CheckBox utilisable = FindName("UtilisableModifier") as CheckBox;

            if (immatriculation == null || nom == null || numero == null) return;

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

            if (immatriculation == null || nom == null || numero == null) return;

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
                            Vehicule_ID = data.Length >= 8 ? String.IsNullOrEmpty(data[7]) ? null : data[7] : null
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
