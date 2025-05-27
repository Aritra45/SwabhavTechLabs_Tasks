import 'package:hive/hive.dart';

part 'product_model.g.dart';

@HiveType(typeId: 0)
class Product extends HiveObject {
  @HiveField(0)
  String name;

  @HiveField(1)
  String description;

  @HiveField(2)
  double price;

  @HiveField(3)
  String image;

  Product({
    required this.name,
    required this.description,
    required this.price,
    required this.image,
  });
}
