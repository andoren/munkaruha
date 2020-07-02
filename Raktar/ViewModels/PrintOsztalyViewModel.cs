using Caliburn.Micro;
using Raktar.Models;
using Raktar.Models.Database;
using System;
using System.Globalization;
using System.Linq;
using System.Printing;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Threading;

namespace Raktar.ViewModels
{
    class PrintOsztalyViewModel : Screen
    {
        public PrintOsztalyViewModel(string osztaly)
        {
            OsztalyName = osztaly;
            Persons = getDataByOsztaly(osztaly);
            Document.FontFamily = new FontFamily("Arial");
            Document.FontSize = 20;

            Thread thread = new Thread(CreateFlowDocument);
            thread.IsBackground = true;
            thread.Start();
        }

        private Visibility progressBarVisiblity = Visibility.Hidden;

        public Visibility ProgressBarVisibilty
        {
            get { return progressBarVisiblity; }
            set { 
                progressBarVisiblity = value;
                NotifyOfPropertyChange(()=> ProgressBarVisibilty);
            }
        }

        private FlowDocument document = new FlowDocument();

        public FlowDocument Document
        {
            get { return document; }
            set
            {
                document = value;
                NotifyOfPropertyChange(() => Document);
            }
        }

        public string PersonCount
        {
            get
            {
                return string.Format("{0} embernek van leltári íve.", Persons.Count);
            }
        }
        public int PersonCountForProgress
        {
            get
            {
                return Persons.Count;

            }
        }
        private int progressBarValue = 0;
        public int ProgressBarValue { get { return progressBarValue; } set { progressBarValue = value; NotifyOfPropertyChange(()=>ProgressBarValue); } }
        private string osztalyName;

        public string OsztalyName
        {
            get { return osztalyName; }
            set
            {
                osztalyName = value;
                NotifyOfPropertyChange(() => OsztalyName);
            }
        }

        private BindableCollection<Dolgozo> persons;

        public BindableCollection<Dolgozo> Persons
        {
            get { return persons; }
            set
            {
                persons = value;
                NotifyOfPropertyChange(() => PersonCount);
            }
        }
        private BindableCollection<Dolgozo> getDataByOsztaly(string osztaly)
        {
            BindableCollection<Dolgozo> persons = new BindableCollection<Dolgozo>();
            BindableCollection<Dolgozo> dolgozok;
            DolgozoDatabaseHelper helper = new DolgozoDatabaseHelper();
            dolgozok = helper.GetDolgozok();
            if (dolgozok.Count() != 0)
            {
                persons = new BindableCollection<Dolgozo>(dolgozok.Where(x => x.GroupName == OsztalyName).ToList());
            }
            return persons;
        }
        public void ExitWindow()
        {
            this.TryClose(false);
        }
        public void PrintAll()
        {

            Document.PageWidth = PrintLayout.A4.Size.Width;
            Document.PageHeight = PrintLayout.A4.Size.Height;
            Document.PagePadding = PrintLayout.A4.Margin;
            Document.ColumnWidth = PrintLayout.A4.ColumnWidth;
            PrintHelper.PrintXPS(Document);

        }
        public void CreateFlowDocument() {
            Image logo;
            Dispatcher.CurrentDispatcher.Invoke(()=> {
                ProgressBarVisibilty = Visibility.Visible;

                //logo előkészítése ezt csak egyszer kell azért a dokumentum előtt van.

            });

            Application.Current.Dispatcher.Invoke(()=> {
                logo = new Image();
                BitmapImage kep = new BitmapImage();
                kep.BeginInit();
                kep.UriSource = new Uri("./Pictrures/fejlecvajda.jpg", UriKind.RelativeOrAbsolute);
                kep.EndInit();
                logo.Source = kep;
            });
            for (int i = 0; i < Persons.Count; i++)
            {
                DolgozoDatabaseHelper helper = new DolgozoDatabaseHelper();
                BindableCollection<Munkaruha> ruhak = new BindableCollection<Munkaruha>();
                foreach (var item in helper.GetRuhakByDolgozoId(Persons[i].Id))
                {
                    ruhak.Add(item);
                }
                if (ruhak.Count == 0) continue;
                int sum = 0;
                foreach (var item in ruhak)
                {
                    sum += item.Osszesen;
                }

                Application.Current.Dispatcher.Invoke(() =>
                {
                    BlockUIContainer logoContainer = new BlockUIContainer();

                    //Új paragrafusban a név és a cím
                    StackPanel stackPanel = new StackPanel();
                    stackPanel.HorizontalAlignment = HorizontalAlignment.Center;
                    TextBlock Title = new TextBlock();
                    Title.Text = "Személyi leltár";
                    Title.HorizontalAlignment = HorizontalAlignment.Center;
                    TextBlock Name = new TextBlock();
                    Name.Text = Persons[i].NameWithGroupName;
                    Name.HorizontalAlignment = HorizontalAlignment.Center;
                    stackPanel.Children.Add(Name);
                    stackPanel.Children.Add(Title);

                    BlockUIContainer TitleAndNameContainer = new BlockUIContainer(stackPanel);
                    TitleAndNameContainer.FontSize = 40;
                    TitleAndNameContainer.TextAlignment = TextAlignment.Center;
                    TitleAndNameContainer.Margin = new Thickness(0, 40, 0, 40);
             
                //Ruhak 
                    BlockUIContainer ruhakContainer = new BlockUIContainer();
                    ruhakContainer.FontSize = 20;
                    ruhakContainer.TextAlignment = TextAlignment.Center;
                    ruhakContainer.Margin = new Thickness(0, 40, 0, 40);
                    DataGrid dataGrid = new DataGrid();
                    dataGrid.ItemsSource = ruhak;
                    dataGrid.Width = 860; dataGrid.AutoGenerateColumns = false; dataGrid.AlternationCount = 1; dataGrid.HeadersVisibility = DataGridHeadersVisibility.Column; dataGrid.IsReadOnly = true;
                    dataGrid.Columns.Add(new DataGridTextColumn() { FontSize = 16, FontFamily = new FontFamily("Arial"), Binding = new Binding("Cikkszam"), Width = new DataGridLength(1, DataGridLengthUnitType.Star), Header = "Cikkszám" });
                    dataGrid.Columns.Add(new DataGridTextColumn() { FontSize = 16, FontFamily = new FontFamily("Arial"), Binding = new Binding("Cikknev"), Width = new DataGridLength(2.5, DataGridLengthUnitType.Star), Header = "Cikknév" });
                    dataGrid.Columns.Add(new DataGridTextColumn() { FontSize = 16, FontFamily = new FontFamily("Arial"), Binding = new Binding("Mennyiseg"), Width = new DataGridLength(0.5, DataGridLengthUnitType.Star), Header = "Me." });
                    dataGrid.Columns.Add(new DataGridTextColumn() { FontSize = 16, FontFamily = new FontFamily("Arial"), Binding = new Binding("Mertekegyseg"), Width = new DataGridLength(0.7, DataGridLengthUnitType.Star), Header = "Me. egység" });
                    dataGrid.Columns.Add(new DataGridTextColumn() { FontSize = 16, FontFamily = new FontFamily("Arial"), Binding = new Binding("FormatedEgysegar"), Width = new DataGridLength(1, DataGridLengthUnitType.Star), Header = "Egységár" });
                    dataGrid.Columns.Add(new DataGridTextColumn() { FontSize = 16, FontFamily = new FontFamily("Arial"), Binding = new Binding("FormatedOsszesen"), Width = new DataGridLength(1, DataGridLengthUnitType.Star), Header = "Összesen" });
                    dataGrid.Columns.Add(new DataGridTextColumn() { FontSize = 16, FontFamily = new FontFamily("Arial"), Binding = new Binding("Bevdatum"), Width = new DataGridLength(1, DataGridLengthUnitType.Star), Header = "Kiadás" });
                    ruhakContainer.Child = dataGrid;


                    //Mindösszesen
                    BlockUIContainer MindosszesenContainer = new BlockUIContainer();
                    MindosszesenContainer.TextAlignment = TextAlignment.Right;
                    MindosszesenContainer.FontSize = 25;

                    StackPanel stackPanel1 = new StackPanel();
                    stackPanel1.HorizontalAlignment = HorizontalAlignment.Right;
                    stackPanel1.VerticalAlignment = VerticalAlignment.Center;
                    stackPanel1.Orientation = Orientation.Horizontal;
                    stackPanel1.Margin = new Thickness(0, 40, 0, 40);
                    TextBlock mindosszesenFelirat = new TextBlock();
                    mindosszesenFelirat.Text = "Mindösszesen:";
                    TextBlock osszesen = new TextBlock();
                    osszesen.FontWeight = FontWeights.Bold;
                    osszesen.Margin = new Thickness(10, 0, 20, 0);

                    osszesen.Text = sum.ToString("C0", CultureInfo.GetCultureInfo("hu"));

                    stackPanel1.Children.Add(mindosszesenFelirat);
                    stackPanel1.Children.Add(osszesen);
                    MindosszesenContainer.Child = stackPanel1;
                    //Készült:
                    BlockUIContainer keszultContainer = new BlockUIContainer();
                    keszultContainer.FontSize = 25;
                    StackPanel stackPanel2 = new StackPanel();

                    TextBlock keszultSzoveg = new TextBlock();
                    keszultSzoveg.Text = "Készült: ";
                    stackPanel2.Children.Add(keszultSzoveg);
                    stackPanel2.Margin = new Thickness(0, 40, 0, 40);
                    TextBlock datum = new TextBlock();
                    datum.Text = string.Format("Szarvas, {0}", DateTime.Today.ToShortDateString());
                    stackPanel2.Children.Add(datum);
                    keszultContainer.Child = stackPanel2;
                    // Aláírások
                    BlockUIContainer alairasokContainer = new BlockUIContainer();
                    alairasokContainer.Margin = new Thickness(0, 40, 0, 40);
                    Grid grid = new Grid();
                    grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) });
                    grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) });
                    grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) });

                    //első aláírás
                    StackPanel elsoStack = new StackPanel();
                    elsoStack.Orientation = Orientation.Vertical;
                    TextBlock potty1 = new TextBlock();
                    potty1.Text = "...........................................";
                    potty1.HorizontalAlignment = HorizontalAlignment.Center;
                    TextBlock leltarFelelos = new TextBlock();
                    leltarFelelos.Text = "Leltár felelős";
                    leltarFelelos.HorizontalAlignment = HorizontalAlignment.Center;
                    elsoStack.Children.Add(potty1);
                    elsoStack.Children.Add(leltarFelelos);
                    grid.Children.Add(elsoStack);

                    //Második aláírás
                    StackPanel masodikStack = new StackPanel();
                    masodikStack.Orientation = Orientation.Vertical;
                    TextBlock potty2 = new TextBlock();
                    potty2.Text = "...........................................";
                    potty2.HorizontalAlignment = HorizontalAlignment.Center;
                    TextBlock leltarEllenor = new TextBlock();
                    leltarEllenor.Text = "Leltár ellenőr";
                    leltarEllenor.HorizontalAlignment = HorizontalAlignment.Center;
                    masodikStack.Children.Add(potty2);
                    masodikStack.Children.Add(leltarEllenor);
                    grid.Children.Add(masodikStack);

                    //Harmadik aláírás
                    StackPanel harmadikStack = new StackPanel();
                    harmadikStack.Orientation = Orientation.Vertical;
                    TextBlock potty3 = new TextBlock();
                    potty3.Text = "...........................................";
                    potty3.HorizontalAlignment = HorizontalAlignment.Center;
                    TextBlock leltarVez = new TextBlock();
                    leltarVez.Text = "Leltározási csop. vez.";
                    leltarVez.HorizontalAlignment = HorizontalAlignment.Center;
                    harmadikStack.Children.Add(potty3);
                    harmadikStack.Children.Add(leltarVez);
                    grid.Children.Add(harmadikStack);

                    Grid.SetColumn(elsoStack, 0);
                    Grid.SetColumn(masodikStack, 1);
                    Grid.SetColumn(harmadikStack, 2);

                    alairasokContainer.Child = grid;

                    //Section hozzáadás szerint adja a flowdocumenthez a blockokat.
                    Section section = new Section();
                    section.Blocks.Add(logoContainer);
                    section.Blocks.Add(TitleAndNameContainer);
                    section.Blocks.Add(ruhakContainer);
                    section.Blocks.Add(MindosszesenContainer);
                    section.Blocks.Add(keszultContainer);
                    section.Blocks.Add(alairasokContainer);
                    section.BreakPageBefore = true;
                    //Hozzáadom a sectiont a Flowdocumenthez
                    document.Blocks.Add(section);                                              
                    ProgressBarValue += 1;

                });           

            }
            Application.Current.Dispatcher.Invoke(()=> {
                ProgressBarVisibilty = Visibility.Hidden;
                ProgressBarValue = 0;
                NotifyOfPropertyChange(() => Document);
            });
        }
    }
}
