using DemoExam.Model.Archive;
using DemoExam.Model.UserPool;
using DemoExam.Repository;
using Microsoft.Office.Interop.Word;
using Word = Microsoft.Office.Interop.Word.Application;

namespace DemoExam.Services
{
    public class OfficeService
    {
        private readonly UserService userService = new();

        public void CreateDocument(Case item)
        {
            //Create an instance for word app
            Word word = new();

            //Set animation status for word application
            word.ShowAnimation = true;

            //Set status for word application is to be visible or not.
            word.Visible = true;

            //Create a missing variable for missing value
            object missing = System.Reflection.Missing.Value;

            //Create a new document
            Document document = word.Documents.Add(ref missing, ref missing, ref missing, ref missing);





            Paragraph heading = document.Content.Paragraphs.Add(ref missing);
            heading.Range.Text = "ПОСТАНОВЛЕНИЕ";
            heading.Range.Font.Bold = 1;
            heading.Range.Font.Name = "Times New Roman";
            heading.Range.Font.Size = 14;
            heading.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
            heading.Range.InsertParagraphAfter();

            Paragraph heading1 = document.Content.Paragraphs.Add(ref missing);
            heading1.Range.Text = "о возбуждении уголовного дела и принятии его к производству";
            heading1.Range.Font.Bold = 1;
            heading1.Range.Font.Name = "Times New Roman";
            heading1.Range.Font.Size = 14;
            heading1.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
            heading1.Range.InsertParagraphAfter();

            Paragraph name = document.Content.Paragraphs.Add(ref missing);
            name.Range.Text = $"Краткое описание: {item.Name}";
            name.Range.Font.Name = "Times New Roman";
            name.Range.Font.Size = 14;
            heading1.Range.Font.Bold = 0;
            heading1.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
            name.Range.InsertParagraphAfter();

            Paragraph intruder = document.Content.Paragraphs.Add(ref missing);
            intruder.Range.Text = $"Нарушитель: {item.Intruder}";
            intruder.Range.Font.Name = "Times New Roman";
            intruder.Range.Font.Size = 14;
            intruder.Range.InsertParagraphAfter();

            Paragraph investigator = document.Content.Paragraphs.Add(ref missing);
            User user = userService.GetById(item.Investigator.Id);
            investigator.Range.Text = $"Следователь: {user.Surname} {user.Name}";
            investigator.Range.Font.Name = "Times New Roman";
            investigator.Range.Font.Size = 14;
            investigator.Range.InsertParagraphAfter();

            Paragraph createdAt = document.Content.Paragraphs.Add(ref missing);
            createdAt.Range.Text = $"Создано: {item.CreatedAt:MM/dd/yyyy HH:mm}";
            createdAt.Range.Font.Name = "Times New Roman";
            createdAt.Range.Font.Size = 14;
            createdAt.Alignment = WdParagraphAlignment.wdAlignParagraphRight;
            createdAt.Range.InsertParagraphAfter();

            //Save the document
            object filename = @"C:\Users\danya\Downloads\temp1.docx";
            document.SaveAs2(ref filename);
            word.Documents.Open(filename);
        }

    }
}
