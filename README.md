# Christmas Lib
Christmas Lib is a VRChat library I wrote in my spare time to reduce duplicate code in various mods. It has evolved from a simple bit of boilerplate code to, in my opinion, a fully fledged modding library for vrchat. A lot of code could of been written in a more efficient way, but this was a learning experience for me.

It includes a button api I wrote, loosely inspired by https://github.com/DubyaDude/RubyButtonAPI.

The Library is a Melonloader plugin and should be placed in the plugins folder.
To use the Library in your code simply reference it.

## Examples

### Using The Button Api
```cs
public override void OnApplicationStart()
{
    //Adds our createMenu Method to the queue of actions for menu creation
    ChristmasUI.OnUiInitActions.Add(CreateMenu);
}
private void CreateMenu()
{
    //Creates a page with the key "Example", the page will be called Example unless changed
    //Keep in mind there cannot be duplicate keys but a page can be renamed to be the same as another
    var examplePage = ChristmasUI.AddPageByName("Example", "This is an example page");
    //Adds a single button to our example page
    examplePage.AddButton(ButtonType.SingleButton, "Single Example", "Single", () => ConsoleUtils.Write("Example button pressed!"));
    //Adds a toggle button.
    examplePage.AddButton(ButtonType.ToggleButton, "Toggle example", "Toggles", null, state => ConsoleUtils.Write(state));
}
```
