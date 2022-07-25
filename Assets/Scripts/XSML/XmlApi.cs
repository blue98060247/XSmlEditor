using System.Collections;
using UnityEngine;

#region"Xml Apis"
using System.Xml;
using System.Xml.Schema;
using System.IO;
using System.Text;
#endregion

public class XmlApi
{
    private XmlSchemaSet xmlSchema;
    private XmlReaderSettings settings;

    private bool failed = false;
    public XmlApi(TextAsset xmlSchema){
        this.xmlSchema = new XmlSchemaSet();
        XmlReader xmls = XmlReader.Create(new StringReader(xmlSchema.text));
        this.xmlSchema.Add("XMLSchema1",xmls);

        settings = new XmlReaderSettings();
        settings.Schemas.Add(this.xmlSchema);
        settings.ValidationType = ValidationType.Schema;
        settings.ValidationEventHandler += new ValidationEventHandler(settingsValidationEventHandler);
    }

    public bool AddXml(string path){
        failed = false;
        XmlReader reader = XmlReader.Create(path, settings);
        //reader.
        // Parse the file.
        try{
            while (reader.Read()) {
                if (reader.IsStartElement()) {
                    if (reader.IsEmptyElement)
                    {
                        Global.logger.WriteLog($"<{reader.Name}/>");
                    }
                    else {
                        Global.logger.WriteLog($"<{reader.Name}> ");
                        reader.Read(); // Read the start tag.
                        if (reader.IsStartElement())  // Handle nested elements.
                            Global.logger.WriteLog($"\r\n<{reader.Name}>");
                        Global.logger.WriteLog(reader.ReadString());  //Read the text content of the element.
                    }
                }
            }       
        }catch{
            failed = true;
        }
        return !failed;
    }

    private void settingsValidationEventHandler(object sender, ValidationEventArgs e)
    {
        if (e.Severity == XmlSeverityType.Warning)
        {
            Global.logger.WriteLog("WARNING: ");
            Global.logger.WriteLog(e.Message);
            failed = true;
        }
        else if (e.Severity == XmlSeverityType.Error)
        {
            Global.logger.WriteLog("ERROR: ");
            Global.logger.WriteLog(e.Message);
            failed = true;
        }
    }
}