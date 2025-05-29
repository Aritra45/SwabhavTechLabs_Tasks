import 'dart:convert';
import 'package:filpkart_clone/pages/ProductsDetails.dart';
import 'package:filpkart_clone/provider/theme_provider.dart';
import 'package:flutter/material.dart';
import 'package:marquee/marquee.dart';
import 'package:provider/provider.dart';
import 'package:smooth_page_indicator/smooth_page_indicator.dart';
import 'custom_bottom_nav.dart';
import 'package:hive/hive.dart';
import 'package:fluttertoast/fluttertoast.dart';

class FlipkartHome extends StatefulWidget {
  const FlipkartHome({super.key});

  @override
  State<FlipkartHome> createState() => _FlipkartHomeState();
}

class _FlipkartHomeState extends State<FlipkartHome> {
  int _selectedIndex = 0;
  bool light = true;
  final List<String> imagePaths = [
    'assets/beardo.jpg',
    'assets/fogg.jpg',
    'assets/boat.jpeg',
  ];

  final PageController _pageController = PageController(initialPage: 1000);
  int _realIndex(int index) => index % imagePaths.length;
  int currentPage = 1000;

  List<dynamic> recommendedProducts = [];

  @override
  void initState() {
    super.initState();
    loadProducts();
  }

  Future<void> loadProducts() async {
    final String jsonStr = await DefaultAssetBundle.of(
      context,
    ).loadString('lib/products/products.json'); // Ensure path is correct
    setState(() {
      recommendedProducts = json.decode(jsonStr);
    });
  }

  void _onItemTapped(int index) {
    if (index == 4) {
      Navigator.pushNamed(context, '/cart');
    } else if (index == 3) {
      Navigator.pushNamed(context, '/order');
    } else if (index == _selectedIndex) {
      return;
    } else {
      setState(() {
        _selectedIndex = index;
      });
    }
  }

  void deleteToken() async {
    final userBox = await Hive.openBox('users');
    userBox.delete('loggedUser');
  }

  @override
  Widget build(BuildContext context) {
    final size = MediaQuery.of(context).size;

    return Scaffold(
      appBar: AppBar(
        automaticallyImplyLeading: false,
        backgroundColor: Colors.blue[700],
        title: const Text(
          'Flipkart',
          style: TextStyle(fontWeight: FontWeight.bold, color: Colors.amber),
        ),
        actions: [
          IconButton(
            onPressed: () {},
            icon: const Icon(Icons.notifications),
            color: Colors.white,
          ),
          IconButton(
            onPressed: () {
              Navigator.pushNamed(context, '/cart');
            },
            icon: const Icon(Icons.shopping_cart),
            color: Colors.white,
          ),
          IconButton(
            onPressed: () {
              try {
                deleteToken();
              Fluttertoast.showToast(
                msg: 'Logout successful',
                backgroundColor: Colors.green,
                textColor: Colors.white,
              );
              Navigator.pushNamedAndRemoveUntil(
                context,
                '/',
                (route) => false,
              );
              } catch (e) {
                Fluttertoast.showToast(
                msg: 'Logout unsuccessful',
                backgroundColor: Colors.red,
                textColor: Colors.white,
              );
              }
              
            },
            icon: const Icon(Icons.logout),
            color: Colors.red,
          ),
        ],
      ),
      body: SingleChildScrollView(
        child: Column(
          children: [
            Container(
              color: Colors.blue[100],
              padding: const EdgeInsets.symmetric(vertical: 12),
              child: Row(
                mainAxisAlignment: MainAxisAlignment.spaceAround,
                children: [
                  _quickIcon(Icons.shopping_bag, "Flipkart"),
                  _quickIcon(Icons.local_grocery_store, "Grocery"),
                  _quickIcon(Icons.flight, "Travel"),
                  _quickIcon(Icons.payment, "Pay"),
                ],
              ),
            ),
            // Padding(
            //   padding: const EdgeInsets.all(8.0),
            //   child: Row(
            //     children: [
            //       const Icon(Icons.location_on),
            //       const Text("400061 "),
            //       GestureDetector(
            //         onTap: () {},
            //         child: Text(
            //           "Select delivery location",
            //           style: TextStyle(
            //             color: Colors.blue[700],
            //             fontWeight: FontWeight.bold,
            //           ),
            //         ),
            //       ),
            //     ],
            //   ),
            // ),
            SizedBox(height: 8),
            Padding(
              padding: const EdgeInsets.symmetric(horizontal: 12),
              child: Row(
                children: [
                  Consumer<ThemeNotifier>(
                    builder:
                        (context, themeNotifier, _) => Row(
                          children: [
                            Text(themeNotifier.isDark ? "Dark" : "Light"),
                            Switch(
                              value: themeNotifier.isDark,
                              onChanged: (value) {
                                themeNotifier.toggleTheme(value);
                              },
                            ),
                          ],
                        ),
                  ),
                  Expanded(
                    child: TextField(
                      decoration: InputDecoration(
                        hintText: "Search for products",
                        prefixIcon: const Icon(Icons.search),
                        border: OutlineInputBorder(
                          borderRadius: BorderRadius.circular(12),
                        ),
                      ),
                    ),
                  ),
                ],
              ),
            ),
            const SizedBox(height: 12),
            Container(
              height: 30,
              color: Colors.yellow[300],
              child: Marquee(
                text: '★ 7 DAYS RETURN ★ FREE DELIVERY ★ 7 DAYS RETURN ★ ',
                style: const TextStyle(
                  fontWeight: FontWeight.bold,
                  color: Colors.black,
                ),
                scrollAxis: Axis.horizontal,
                crossAxisAlignment: CrossAxisAlignment.center,
                blankSpace: 50.0,
                velocity: 50.0,
                pauseAfterRound: const Duration(seconds: 1),
                startPadding: 10.0,
                accelerationDuration: const Duration(seconds: 1),
                accelerationCurve: Curves.linear,
                decelerationDuration: const Duration(milliseconds: 500),
                decelerationCurve: Curves.easeOut,
              ),
            ),
            SizedBox(height: 5),
            Column(
              children: [
                SizedBox(
                  height: size.height * 0.22,
                  child: PageView.builder(
                    controller: _pageController,
                    onPageChanged: (index) {
                      setState(() {
                        currentPage = index;
                      });
                    },
                    itemBuilder: (context, index) {
                      final imagePath = imagePaths[_realIndex(index)];
                      return Container(
                        margin: const EdgeInsets.symmetric(horizontal: 12),
                        decoration: BoxDecoration(
                          borderRadius: BorderRadius.circular(12),
                          image: DecorationImage(
                            image: AssetImage(imagePath),
                            fit: BoxFit.cover,
                          ),
                        ),
                      );
                    },
                  ),
                ),
                const SizedBox(height: 8),
                SmoothPageIndicator(
                  controller: _pageController,
                  count: imagePaths.length,
                  effect: WormEffect(
                    dotHeight: 8,
                    dotWidth: 8,
                    spacing: 6,
                    activeDotColor: Colors.black,
                    dotColor: Colors.grey.shade300,
                  ),
                ),
              ],
            ),
            const SizedBox(height: 10),
            Padding(
              padding: const EdgeInsets.symmetric(horizontal: 12),
              child: Row(
                mainAxisAlignment: MainAxisAlignment.spaceBetween,
                children: [
                  _categoryIcon(Icons.spa, "Beauty"),
                  _categoryIcon(Icons.person, "Fashion"),
                  _categoryIcon(Icons.watch, "Gadgets"),
                  _categoryIcon(Icons.chair, "Home"),
                  _categoryIcon(Icons.tv, "Appliances"),
                ],
              ),
            ),
            const SizedBox(height: 16),
            Container(
              width: double.infinity,
              color: Colors.blue[50],
              padding: const EdgeInsets.all(12),
              child: const Text(
                "Aritra, still looking for these?",

                style: TextStyle(
                  fontWeight: FontWeight.bold,
                  fontSize: 16,
                  color: Colors.black,
                ),
              ),
            ),
            SizedBox(
              height: 180,
              child:
                  recommendedProducts.isEmpty
                      ? const Center(child: CircularProgressIndicator())
                      : ListView.builder(
                        scrollDirection: Axis.horizontal,
                        padding: const EdgeInsets.symmetric(horizontal: 8),
                        itemCount: recommendedProducts.length,
                        itemBuilder: (context, index) {
                          final product = recommendedProducts[index];
                          return _recommendedCard(
                            product['name'],
                            product['image'],

                            onPressed: () {
                              Navigator.push(
                                context,
                                MaterialPageRoute(
                                  builder:
                                      (context) => ProductDetailsPage(
                                        productName: product['name'] ?? '',
                                        productDescription:
                                            product['description'] ?? '',
                                        productPrice:
                                            (product['price'] ?? 0).toDouble(),
                                        productImageUrl: product['image'] ?? '',
                                      ),
                                ),
                              );
                            },
                          );
                        },
                      ),
            ),
          ],
        ),
      ),
      bottomNavigationBar: CustomBottomNavBar(
        currentIndex: _selectedIndex,
        onTap: _onItemTapped,
      ),
    );
  }

  Widget _quickIcon(IconData icon, String label) => Column(
    children: [
      CircleAvatar(
        backgroundColor: Colors.white,
        child: Icon(icon, color: Colors.blue),
      ),
      const SizedBox(height: 4),
      Text(label, style: const TextStyle(fontSize: 12)),
    ],
  );

  Widget _categoryIcon(IconData icon, String label) {
    return Column(
      children: [
        CircleAvatar(child: Icon(icon, size: 20)),
        const SizedBox(height: 4),
        Text(label, style: const TextStyle(fontSize: 12)),
      ],
    );
  }

  Widget _recommendedCard(
    String title,
    String imgUrl, {
    VoidCallback? onPressed,
  }) => GestureDetector(
    onTap: onPressed,
    child: Container(
      width: 110,
      margin: const EdgeInsets.symmetric(horizontal: 8, vertical: 10),
      decoration: BoxDecoration(
        color: Colors.white,
        borderRadius: BorderRadius.circular(12),
        border: Border.all(color: Colors.grey.shade300),
      ),
      child: Column(
        mainAxisAlignment: MainAxisAlignment.center,
        children: [
          Image.network(imgUrl, height: 60, fit: BoxFit.cover),
          const SizedBox(height: 8),
          Text(
            title,
            textAlign: TextAlign.center,
            style: const TextStyle(fontSize: 12, color: Colors.black),
          ),
        ],
      ),
    ),
  );
}
