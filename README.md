# Nth MultiLanguage
Simple and easy to use multi-language / localization support library for .Net applications. It supports loading language strings from XML files and allow grouping of translation strings for better manageability.

It currently supports loading language strings from XML files but designed to support any type of source.

## How to use
- **Prepare an XML file for each language**

Sample XML file for English (English.xml)
```xml
<?xml version="1.0"?>
<Language Code="en-US" Name="English">
  <Groups>
    <Group Name="General">
      <Item Name="Yes" Value="Yes" />
      <Item Name="No" Value="No" />
      <Item Name="OK" Value="OK" />
      ...
    </Group>
    <Group Name="MainForm">
      <Item Name="FormTitle" Value="Sample application" />
      ...
    </Group>
  </Groups>
</Language>
```

Sample XML file for Turkish (Turkish.xml)
```xml
<?xml version="1.0"?>
<Language Code="tr-TR" Name="Turkish">
  <Groups>
    <Group Name="General">
      <Item Name="Yes" Value="Evet" />
      <Item Name="No" Value="Hayır" />
      <Item Name="OK" Value="Tamam" />
      ...
    </Group>
    <Group Name="MainForm">
      <Item Name="FormTitle" Value="Örnek uygulama" />
      ...
    </Group>
  </Groups>
</Language>
```

- **Prepare language objects**

```csharp
string _xmlLangugeFilesFolder = Path.GetFullPath(@"..\..\SampleData\XML");

XmlFileSource _xmlfileSource = new XmlFileSource(_xmlLangugeFilesFolder);

MultiLanguageProvider _languageProvider = new MultiLanguageProvider(_xmlfileSource);
_languageProvider.SetCurrentLanguage("tr-TR");
```

- **Read strings wherever you need**

```csharp
//Get the string by providing its group and name
this.Text = _languageProvider.GetString("MainForm", "FormTitle");

//You can also get the string only by passing its name
m_btnOK.Text = _languageProvider.GetString("OK");
```
