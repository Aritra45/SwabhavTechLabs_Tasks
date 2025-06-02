import 'package:flutter/material.dart';
import 'package:hive_flutter/hive_flutter.dart';
import '../models/product_model.dart';
import 'custom_bottom_nav.dart';

class CartPage extends StatefulWidget {
  const CartPage({super.key});

  @override
  State<CartPage> createState() => _CartPageState();
}

class _CartPageState extends State<CartPage> {
  late Box<Product> cartBox;
  int _selectedIndex = 4;
  Map<int, bool> selectedItems = {};
  Map<int, int> productQuantities = {};

  @override
  void initState() {
    super.initState();
    cartBox = Hive.box<Product>('cartBox');
  }

  void _onItemTapped(int index) {
    if (index == _selectedIndex) return;
    if (index == 0) {
      Navigator.pushNamedAndRemoveUntil(context, '/home', (route) => false);
    } else if (index == 3) {
      Navigator.pushNamed(context, '/order');
    } else {
      setState(() {
        _selectedIndex = index;
      });
    }
  }

  @override
  Widget build(BuildContext context) {
    return DefaultTabController(
      length: 2,
      child: Scaffold(
        appBar: AppBar(
          automaticallyImplyLeading: false,
          title: const Text('My Cart', style: TextStyle(color: Colors.black)),
          backgroundColor: Colors.white,
          elevation: 0,
          bottom: const TabBar(
            labelColor: Colors.blue,
            unselectedLabelColor: Colors.black,
            indicatorColor: Colors.blue,
            tabs: [Tab(text: 'Flipkart'), Tab(text: 'Grocery')],
          ),
        ),
        body: Column(
          children: [
            Expanded(
              child: TabBarView(children: [_buildCartTab(), _buildCartTab()]),
            ),
          ],
        ),
        bottomNavigationBar: CustomBottomNavBar(
          currentIndex: _selectedIndex,
          onTap: _onItemTapped,
        ),
      ),
    );
  }

  // Replace inside _buildCartTab method
  Widget _buildCartTab() {
    return ValueListenableBuilder(
      valueListenable: cartBox.listenable(),
      builder: (context, Box<Product> box, _) {
        if (box.isEmpty) return _buildEmptyCart();

        final keys = box.keys.cast<int>().toList().reversed.toList();

        double totalPrice = 0.0;
        for (int key in keys) {
          selectedItems.putIfAbsent(key, () => false);
          productQuantities.putIfAbsent(key, () => 1);
          if (selectedItems[key] == true) {
            totalPrice +=
                (box.get(key)?.price ?? 0.0) * (productQuantities[key] ?? 1);
          }
        }

        return Column(
          children: [
            Expanded(
              child: ListView.builder(
                itemCount: keys.length,
                itemBuilder: (context, index) {
                  final key = keys[index];
                  final product = box.get(key);

                  if (product == null) return const SizedBox();

                  return Card(
                    margin: const EdgeInsets.symmetric(
                      horizontal: 12,
                      vertical: 8,
                    ),
                    child: Padding(
                      padding: const EdgeInsets.all(12.0),
                      child: Column(
                        crossAxisAlignment: CrossAxisAlignment.start,
                        children: [
                          Row(
                            children: [
                              Checkbox(
                                value: selectedItems[key] ?? false,
                                onChanged: (bool? value) {
                                  setState(() {
                                    selectedItems[key] = value ?? false;
                                  });
                                },
                              ),
                              const SizedBox(width: 8),
                              product.image.isNotEmpty &&
                                      Uri.tryParse(
                                            product.image,
                                          )?.hasAbsolutePath ==
                                          true
                                  ? Image.network(
                                    product.image,
                                    width: 60,
                                    height: 60,
                                    fit: BoxFit.cover,
                                    errorBuilder:
                                        (context, error, stackTrace) =>
                                            const Icon(Icons.broken_image),
                                  )
                                  : const Icon(Icons.broken_image, size: 60),

                              const SizedBox(width: 12),
                              Expanded(
                                child: Column(
                                  crossAxisAlignment: CrossAxisAlignment.start,
                                  children: [
                                    Text(
                                      product.name,
                                      style: const TextStyle(
                                        fontWeight: FontWeight.bold,
                                      ),
                                    ),
                                    const SizedBox(height: 4),
                                    Text(
                                      '₹ ${product.price.toStringAsFixed(2)}',
                                      style: const TextStyle(
                                        color: Colors.grey,
                                      ),
                                    ),
                                  ],
                                ),
                              ),
                            ],
                          ),
                          const SizedBox(height: 10),
                          Row(
                            children: [
                              IconButton(
                                onPressed: () {
                                  setState(() {
                                    if ((productQuantities[key] ?? 1) > 1) {
                                      productQuantities[key] =
                                          (productQuantities[key] ?? 1) - 1;
                                    }
                                  });
                                },
                                icon: const Icon(Icons.remove_circle_outline),
                              ),
                              Text('${productQuantities[key] ?? 1}'),
                              IconButton(
                                onPressed: () {
                                  setState(() {
                                    productQuantities[key] =
                                        (productQuantities[key] ?? 1) + 1;
                                  });
                                },
                                icon: const Icon(Icons.add_circle_outline),
                              ),
                              const Spacer(),
                            ],
                          ),
                          Align(
                            alignment: Alignment.bottomRight,
                            child: TextButton.icon(
                              onPressed: () {
                                setState(() {
                                  cartBox.delete(key);
                                  selectedItems.remove(key);
                                  productQuantities.remove(key);
                                });
                              },
                              icon: const Icon(Icons.delete, color: Colors.red),
                              label: const Text(
                                "Delete",
                                style: TextStyle(color: Colors.red),
                              ),
                            ),
                          ),
                        ],
                      ),
                    ),
                  );
                },
              ),
            ),

            /// Checkout Section
            Container(
              padding: const EdgeInsets.symmetric(horizontal: 16, vertical: 12),
              decoration: BoxDecoration(
                border: Border(top: BorderSide(color: Colors.grey.shade300)),
                color: Colors.white,
              ),
              child: Column(
                children: [
                  Row(
                    mainAxisAlignment: MainAxisAlignment.spaceBetween,
                    children: [
                      const Text(
                        'Total:',
                        style: TextStyle(
                          fontSize: 18,
                          fontWeight: FontWeight.bold,
                          color: Colors.black,
                        ),
                      ),
                      Text(
                        '₹ ${totalPrice.toStringAsFixed(2)}',
                        style: const TextStyle(
                          fontSize: 18,
                          fontWeight: FontWeight.bold,
                          color: Colors.black,
                        ),
                      ),
                    ],
                  ),
                  const SizedBox(height: 10),
                  SizedBox(
                    width: double.infinity,
                    child: ElevatedButton(
                      onPressed:
                          totalPrice > 0
                              ? () async {
                                final orderBox = Hive.box<Product>('ordersBox');
                                final selectedKeys =
                                    keys
                                        .where(
                                          (key) => selectedItems[key] == true,
                                        )
                                        .toList();

                                for (int key in selectedKeys) {
                                  final product = cartBox.get(key);
                                  if (product != null) {
                                    final quantity =
                                        productQuantities[key] ?? 1;
                                    for (int i = 0; i < quantity; i++) {
                                      final clonedProduct = Product(
                                        name: product.name,
                                        description : product.description,
                                        price: product.price,
                                        image: product.image,
                                      );
                                      await orderBox.add(clonedProduct);
                                    }
                                    await cartBox.delete(key);
                                    selectedItems.remove(key);
                                    productQuantities.remove(key);
                                  }
                                }

                                setState(() {});
                                Navigator.pushNamed(context, '/order');
                              }
                              : null,
                      style: ButtonStyle(
                        backgroundColor:
                            MaterialStateProperty.resolveWith<Color>((
                              Set<MaterialState> states,
                            ) {
                              if (states.contains(MaterialState.disabled)) {
                                return Colors.grey.shade500;
                              }
                              return Colors.blue;
                            }),
                        padding: MaterialStateProperty.all(
                          const EdgeInsets.symmetric(vertical: 14),
                        ),
                        shape: MaterialStateProperty.all(
                          RoundedRectangleBorder(
                            borderRadius: BorderRadius.circular(8),
                          ),
                        ),
                      ),
                      child: const Text(
                        'Checkout',
                        style: TextStyle(fontSize: 16, color: Colors.black),
                      ),
                    ),
                  ),
                ],
              ),
            ),
          ],
        );
      },
    );
  }

  Widget _buildEmptyCart() {
    return SingleChildScrollView(
      child: Column(
        children: [
          const SizedBox(height: 40),
          Image.asset(
            'assets/sopping.png',
            height: 120,
          ),
          const SizedBox(height: 20),
          const Text(
            'Your cart is empty!',
            style: TextStyle(fontSize: 18, fontWeight: FontWeight.bold),
          ),
          const SizedBox(height: 20),
          ElevatedButton(
            onPressed: () {
              Navigator.pushNamed(context, '/home');
            },
            style: ElevatedButton.styleFrom(
              backgroundColor: Colors.blue,
              padding: const EdgeInsets.symmetric(horizontal: 32, vertical: 12),
              shape: RoundedRectangleBorder(
                borderRadius: BorderRadius.circular(8),
              ),
            ),
            child: const Text(
              'Shop now',
              style: TextStyle(color: Colors.black),
            ),
          ),
          const SizedBox(height: 30),
          Container(
            width: double.infinity,
            alignment: Alignment.centerLeft,
            padding: const EdgeInsets.symmetric(horizontal: 16),
            child: const Column(
              crossAxisAlignment: CrossAxisAlignment.start,
              children: [
                Text(
                  "Suggested for You",
                  style: TextStyle(fontWeight: FontWeight.bold, fontSize: 16),
                ),
                SizedBox(height: 4),
                Text(
                  "Based on Your Activity",
                  style: TextStyle(color: Colors.grey),
                ),
              ],
            ),
          ),
          const SizedBox(height: 12),
          SizedBox(
            height: 180,
            child: ListView(
              scrollDirection: Axis.horizontal,
              padding: const EdgeInsets.symmetric(horizontal: 8),
              children: [
                _suggestedItem(
                  "assets/products/suitcase.jpeg",
                  "Suitcase",
                ),
                _suggestedItem(
                  "assets/products/laptop-table.png",
                  "Laptop Table",
                ),
                _suggestedItem(
                  "assets/products/snacks.png",
                  "Snacks",
                ),
              ],
            ),
          ),
        ],
      ),
    );
  }

  static Widget _suggestedItem(String imageUrl, String title) {
    return Container(
      width: 120,
      margin: const EdgeInsets.symmetric(horizontal: 8),
      decoration: BoxDecoration(
        borderRadius: BorderRadius.circular(12),
        border: Border.all(color: Colors.grey.shade300),
        color: Colors.white,
      ),
      child: Column(
        mainAxisAlignment: MainAxisAlignment.center,
        children: [
          Image.asset(imageUrl, height: 100, fit: BoxFit.cover),
          const SizedBox(height: 8),
          Padding(
            padding: const EdgeInsets.symmetric(horizontal: 4),
            child: Text(
              title,
              textAlign: TextAlign.center,
              style: const TextStyle(fontSize: 13, color: Colors.black),
            ),
          ),
        ],
      ),
    );
  }
}
