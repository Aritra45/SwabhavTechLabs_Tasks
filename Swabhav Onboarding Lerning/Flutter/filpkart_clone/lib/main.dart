import 'pages/ProductsDetails.dart';
import 'package:flutter/material.dart';
import 'pages/flipkartHome.dart';
import 'pages/loading.dart';
import 'pages/cart.dart';
import 'pages/order.dart';
import 'package:hive_flutter/hive_flutter.dart';
import 'models/product_model.dart';
import 'provider/cart_provider.dart';
import 'package:provider/provider.dart';

void main() async {
  WidgetsFlutterBinding.ensureInitialized();
  await Hive.initFlutter();
  Hive.registerAdapter(ProductAdapter());
  await Hive.openBox<Product>('cartBox');
  await Hive.openBox<Product>('ordersBox');

  runApp(
    ChangeNotifierProvider(
      create: (_) => CartProvider(),
      child: const FlipkartApp(),
    ),
  );
}

class FlipkartApp extends StatelessWidget {
  const FlipkartApp({super.key});

  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      debugShowCheckedModeBanner: false,
      initialRoute: '/',
      routes: {
        '/': (context) => const Loading(),
        '/home': (context) => const FlipkartHome(),
        '/cart': (context) => const CartPage(),
        '/order': (context) => const MyOrdersPage(),
        '/details': (context) => const ProductDetailsPage(),
      },
    );
  }
}
