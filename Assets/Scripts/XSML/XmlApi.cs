using System.Collections.Generic;
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
    private Dictionary<string,XmlTree> xmlTreeDict;

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
        XmlTree newXmlTree = null;
        //reader.
        // Parse the file.
        try{
            while (reader.Read()) {
                //Global.logger.WriteLog($"type: {reader.NodeType}");
                if (reader.IsStartElement()) {
                    if (reader.IsEmptyElement)
                    {
                        Global.Log($"get empty element: <{reader.Name}/>");
                    }
                    else {
                        string name = reader.Name;
                        //Global.logger.WriteLog($"<{reader.Name}>");
                        //if(reader.HasAttributes){
                        //    for(int i = 0; i < reader.AttributeCount; i++){
                        //        
                        //        Global.logger.WriteLog($"<{reader.GetAttribute(i)}>");
                        //    }
                        //}
                        reader.Read(); // Read the start tag.
                        if (reader.IsStartElement())  // Handle nested elements.
                        {
                            //Global.logger.WriteLog($"\r\n<{reader.Name}>");

                        }
                        Global.Log(reader.ReadString());  //Read the text content of the element.
                    }
                }
            }       
        }catch{
            failed = true;
        }
        return !failed;
    }

    //private void AddNewTree()

    private void settingsValidationEventHandler(object sender, ValidationEventArgs e)
    {
        if (e.Severity == XmlSeverityType.Warning)
        {
            Global.Log("WARNING: ");
            Global.Log(e.Message);
            failed = true;
        }
        else if (e.Severity == XmlSeverityType.Error)
        {
            Global.Log("ERROR: ");
            Global.Log(e.Message);
            failed = true;
        }
    }
}

public class XmlTree{
    public string node {get;private set;}
    public string value {get;private set;}
    public XmlTree[] leaf {get;private set;}
    public int nextPointer;
    
    public XmlTree(string node){
        this.node = node;
    }

    public void SetTree(XmlTree[] leaf, int next = 0){
        this.leaf = leaf;
        this.nextPointer = next;
    }

    public void SetTree(XmlTree leaf){
        this.leaf = new XmlTree[] { leaf };
        this.nextPointer = 0;
    }
    
    public void SetValue(string value){

    }

    public XmlTree GetNext(){
        return leaf[nextPointer];
    }
}