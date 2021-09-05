/// If you want to use setState method in your components you can use [Component]
/// "class YourCustomComponent implements Component"
/// -"class _YourScreenState extends State<YourScreen> with YourCustomComponent"
abstract class Component {
  ///  override whenComplete(){ if(mounted)setState(){}; }
  void whenComplete(); // For State Management
}
