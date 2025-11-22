using System;

namespace AbstractFactory;

public interface IButton
{
  void Render();
}

public interface ICheckbox
{
  void Toggle();
}

public interface IWidgetFactory
{
  IButton CreateButton();
  ICheckbox CreateCheckbox();
}

public class LightButton : IButton
{
  public void Render() => Console.WriteLine("Rendering light button");
}

public class DarkButton : IButton
{
  public void Render() => Console.WriteLine("Rendering dark button");
}

public class LightCheckbox : ICheckbox
{
  public void Toggle() => Console.WriteLine("Light checkbox toggled");
}

public class DarkCheckbox : ICheckbox
{
  public void Toggle() => Console.WriteLine("Dark checkbox toggled");
}

public class LightThemeFactory : IWidgetFactory
{
  public IButton CreateButton() => new LightButton();
  public ICheckbox CreateCheckbox() => new LightCheckbox();
}

public class DarkThemeFactory : IWidgetFactory
{
  public IButton CreateButton() => new DarkButton();
  public ICheckbox CreateCheckbox() => new DarkCheckbox();
}

public class SettingsPanel(IWidgetFactory factory)
{
  private readonly IButton button = factory.CreateButton();
  private readonly ICheckbox checkbox = factory.CreateCheckbox();

  public void Draw()
  {
    button.Render();
    checkbox.Toggle();
  }
}

class Program
{
  static void Main(string[] args)
  {
    Console.WriteLine("=== Abstract Factory Pattern Demo ===");
    Console.WriteLine();

    Console.WriteLine("Light theme:");
    var lightPanel = new SettingsPanel(new LightThemeFactory());
    lightPanel.Draw();

    Console.WriteLine();
    Console.WriteLine("Dark theme:");
    var darkPanel = new SettingsPanel(new DarkThemeFactory());
    darkPanel.Draw();

    Console.WriteLine();
    Console.WriteLine("Press any key to exit...");
    Console.ReadKey();
  }
}
