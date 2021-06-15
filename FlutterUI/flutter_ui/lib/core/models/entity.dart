import 'package:reflectable/reflectable.dart';

class Entity extends Reflectable {
  const Entity() : super(invokingCapability);
}

const entity = const Entity();
