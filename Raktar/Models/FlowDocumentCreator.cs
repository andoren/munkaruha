using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;
using Caliburn.Micro;

namespace Raktar.Models
{
    class FlowDocumentCreator
    {
        public FlowDocumentCreator(Dolgozo Dolgozo, BindableCollection<Munkaruha> Ruhak)
        {
            this.Dolgozo = Dolgozo;
            this.Ruhak = Ruhak;
        }

        public Dolgozo Dolgozo { get; private set; }
        public BindableCollection<Munkaruha> Ruhak { get; private set; }
        private Paragraph CreateHeader() {
            Paragraph header = new Paragraph();
            TextBlock NameInHeader = new TextBlock()
            {
                Text = Dolgozo.NameWithGroupName,

            };
            NameInHeader.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
            NameInHeader.FontSize = 18;
            NameInHeader.FontFamily = new FontFamily("Times New Roman");
            header.Inlines.Add(NameInHeader);
            return header;
        }
        private Paragraph CreateBody() {
            return new Paragraph(new Run("I'm the body"));
        }
        private Paragraph CreateFooter()
        {
            return new Paragraph(new Run("I'm the footer"));
        }
        private Section CreateSection() {
            Section section = new Section();
            section.Blocks.Add(CreateHeader());
            section.Blocks.Add(CreateBody());
            section.Blocks.Add(CreateFooter());
            return section;
        }
        public FlowDocument CreateFlowDocument() {

            FlowDocument flowDocument = new FlowDocument();
            flowDocument.FontFamily = new FontFamily("Times New Roman");
            flowDocument.FontSize = 14;
            flowDocument.ColumnWidth = 992;
            Section section = CreateSection();
            flowDocument.Blocks.Add(section);

            return flowDocument;
        }

    }
}
