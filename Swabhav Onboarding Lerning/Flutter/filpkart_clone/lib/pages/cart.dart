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
  Map<int, bool> selectedItems = {}; // Track selected items
  Map<int, int> productQuantities = {}; // Track product quantities

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
              child: TabBarView(
                children: [
                  _buildCartTab(),
                  _buildCartTab(), // Reuse for now
                ],
              ),
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

  Widget _buildCartTab() {
    return ValueListenableBuilder(
      valueListenable: cartBox.listenable(),
      builder: (context, Box<Product> box, _) {
        if (box.isEmpty) return _buildEmptyCart();

        for (int i = 0; i < box.length; i++) {
          selectedItems.putIfAbsent(i, () => false);
          productQuantities.putIfAbsent(i, () => 1);
        }

        double totalPrice = 0.0;
        selectedItems.forEach((index, selected) {
          if (selected) {
            totalPrice +=
                (box.getAt(index)?.price ?? 0.0) *
                (productQuantities[index] ?? 1);
          }
        });

        return Column(
          children: [
            Expanded(
              child: ListView.builder(
                itemCount: box.length,
                itemBuilder: (context, index) {
                  int reverseIndex = box.length - 1 - index;
                  final product = box.getAt(reverseIndex);

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
                                value: selectedItems[reverseIndex] ?? false,
                                onChanged: (bool? value) {
                                  setState(() {
                                    selectedItems[reverseIndex] =
                                        value ?? false;
                                  });
                                },
                              ),
                              const SizedBox(width: 8),
                              Image.network(
                                product?.image ?? '',
                                width: 60,
                                height: 60,
                                fit: BoxFit.cover,
                              ),
                              const SizedBox(width: 12),
                              Expanded(
                                child: Column(
                                  crossAxisAlignment: CrossAxisAlignment.start,
                                  children: [
                                    Text(
                                      product?.name ?? '',
                                      style: const TextStyle(
                                        fontWeight: FontWeight.bold,
                                      ),
                                    ),
                                    const SizedBox(height: 4),
                                    Text(
                                      '₹ ${product?.price.toStringAsFixed(2)}',
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
                                    if ((productQuantities[reverseIndex] ?? 1) >
                                        1) {
                                      productQuantities[reverseIndex] =
                                          (productQuantities[reverseIndex] ??
                                              1) -
                                          1;
                                    }
                                  });
                                },
                                icon: const Icon(Icons.remove_circle_outline),
                              ),
                              Text('${productQuantities[reverseIndex] ?? 1}'),
                              IconButton(
                                onPressed: () {
                                  setState(() {
                                    productQuantities[reverseIndex] =
                                        (productQuantities[reverseIndex] ?? 1) +
                                        1;
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
                                  box.deleteAt(reverseIndex);
                                  selectedItems.remove(reverseIndex);
                                  productQuantities.remove(reverseIndex);
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
            // Checkout and total section remains unchanged
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
                        ),
                      ),
                      Text(
                        '₹ ${totalPrice.toStringAsFixed(2)}',
                        style: const TextStyle(
                          fontSize: 18,
                          fontWeight: FontWeight.bold,
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
                                final List<int> selectedKeys = [];

                                for (int i = 0; i < cartBox.length; i++) {
                                  final product = cartBox.getAt(i);
                                  if (selectedItems[i] == true &&
                                      product != null) {
                                    final quantity = productQuantities[i] ?? 1;
                                    for (int j = 0; j < quantity; j++) {
                                      await orderBox.add(
                                        Product(
                                          name: product.name,
                                          description: product.description,
                                          price: product.price,
                                          image: product.image,
                                        ),
                                      );
                                    }
                                    selectedKeys.add(i);
                                  }
                                }

                                selectedKeys.sort((a, b) => b.compareTo(a));
                                for (int key in selectedKeys) {
                                  await cartBox.deleteAt(key);
                                  selectedItems.remove(key);
                                  productQuantities.remove(key);
                                }

                                setState(() {});
                                Navigator.pushNamed(context, '/order');
                              }
                              : null,
                      style: ElevatedButton.styleFrom(
                        backgroundColor: Colors.blue,
                        padding: const EdgeInsets.symmetric(vertical: 14),
                        shape: RoundedRectangleBorder(
                          borderRadius: BorderRadius.circular(8),
                        ),
                      ),
                      child: const Text(
                        'Checkout',
                        style: TextStyle(fontSize: 16),
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
          Image.network(
            'https://cdn-icons-png.flaticon.com/512/2038/2038854.png',
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
            child: const Text('Shop now'),
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
                _suggestedItem("https://via.placeholder.com/120", "Suitcase"),
                _suggestedItem(
                  "https://via.placeholder.com/120",
                  "Laptop Table",
                ),
                _suggestedItem("https://via.placeholder.com/120", "Snacks"),
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
          Image.network(imageUrl, height: 100, fit: BoxFit.cover),
          const SizedBox(height: 8),
          Padding(
            padding: const EdgeInsets.symmetric(horizontal: 4),
            child: Text(
              title,
              textAlign: TextAlign.center,
              style: const TextStyle(fontSize: 13),
            ),
          ),
        ],
      ),
    );
  }
}
