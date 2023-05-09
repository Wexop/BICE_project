using BICE.DTO;
using BICE.SRV;
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

        private int findCategorieId(string categorieString)
        {
            var categorieSrv = new Categorie_SRV();

            var allCategorie = categorieSrv.GetAll();

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
                var newCategorieDTO = new Categorie_DTO()
                {
                    Nom = categorieString
                };

                categorieSrv.Ajouter(newCategorieDTO);
                findCategorieId(categorieString);
            }

            return categorieID;
        }

        private void UploadButton_Add_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog();
            bool? result = openFileDialog.ShowDialog();
            var list = new List<Materiel_DTO>();

            if (result == true)
            {
                using (StreamReader reader = new StreamReader(openFileDialog.FileName))
                {
                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        var data = line.Split(';');

                        var categorieString = data[2];

                        var categorieID = findCategorieId(categorieString);

                        var dto = new Materiel_DTO()
                        {
                            CodeBarre = data[0],
                            Nom = data[1],
                            Categorie_ID = categorieID,
                            Nb_utilisation = String.IsNullOrEmpty(data[3]) ? null : int.Parse(data[3]),
                            Nb_utilisation_max = String.IsNullOrEmpty(data[4]) ? null : int.Parse(data[4]),
                            Date_peremption = data[5] == "" ? null : DateTime.Parse(data[5]),
                            Date_controle = data[6] == "" ? null : DateTime.Parse(data[6]),
                            Date_prochain_controle = data[6] == "" ? null : DateTime.Parse(data[6]),
                            Stock = bool.Parse(data[7])
                        };


                        list.Add(dto);
                        Trace.WriteLine(dto.CodeBarre);
                    }

                }

            }
        }

    }
}
