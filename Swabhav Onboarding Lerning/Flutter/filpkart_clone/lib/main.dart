import 'package:filpkart_clone/pages/loginRegister.dart';

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
import 'provider/theme_provider.dart';

void main() async {
  WidgetsFlutterBinding.ensureInitialized();
  await Hive.initFlutter();

  // Register Hive adapters
  Hive.registerAdapter(ProductAdapter());

  // Open necessary Hive boxes
  await Hive.openBox<Product>('cartBox');
  await Hive.openBox<Product>('ordersBox');
  await Hive.openBox('users'); // Open users box for login/register

  runApp(
    MultiProvider(
      providers: [
        ChangeNotifierProvider(create: (_) => CartProvider()),
        ChangeNotifierProvider(create: (_) => ThemeNotifier()),
      ],
      child: const FlipkartApp(),
    ),
  );
}

class FlipkartApp extends StatelessWidget {
  const FlipkartApp({super.key});

  @override
  Widget build(BuildContext context) {
    final themeNotifier = Provider.of<ThemeNotifier>(context);

    return MaterialApp(
      debugShowCheckedModeBanner: false,
      theme: ThemeData.light(),
      darkTheme: ThemeData.dark(),
      themeMode: themeNotifier.currentTheme,
      initialRoute: '/',
      routes: {
        '/': (context) => const Loading(),
        '/home': (context) => const FlipkartHome(),
        '/cart': (context) => const CartPage(),
        '/order': (context) => const MyOrdersPage(),
        '/details': (context) => const ProductDetailsPage(),
        '/login': (context) => const FlipkartAuthPage(),
      },
    );
  }
}
