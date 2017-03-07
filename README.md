# Nth MultiLanguage
Simple and easy to use multi-language / localization support library for .Net applications. It supports loading language strings from XML files and allow grouping of translation strings for better manageability.

It currently supports loading language strings from XML files but designed to support any type of source.

## How to use
- **Prepare an XML file for each language**

Sample XML file
```xml
<?xml version="1.0"?>
<Language Code="tr-TR" Name="English">
  <Groups>
    <Group Name="General">
      <Item Name="Yes" Value="Evet" />
      <Item Name="No" Value="Hayýr" />
      <Item Name="OK" Value="Tamam" />
      ...
    </Group>
    <Group Name="MainForm">
      <Item Name="FormTitle" Value="" />
      ...
    </Group>
  </Groups>
</Language>
```