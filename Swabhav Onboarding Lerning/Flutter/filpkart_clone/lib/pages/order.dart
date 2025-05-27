import 'package:flutter/material.dart';
import 'package:hive_flutter/hive_flutter.dart';
import '../models/product_model.dart';
import 'custom_bottom_nav.dart';

class MyOrdersPage extends StatefulWidget {
  const MyOrdersPage({super.key});

  @override
  State<MyOrdersPage> createState() => _MyOrdersPageState();
}

class _MyOrdersPageState extends State<MyOrdersPage> {
  int _selectedIndex = 3;
  late Box<Product> ordersBox;
  String _searchQuery = '';
  String? _selectedCategory;

  final TextEditingController _searchController = TextEditingController();

  @override
  void initState() {
    super.initState();
    ordersBox = Hive.box<Product>('ordersBox');
  }

  void _onItemTapped(int index) {
    if (index == _selectedIndex) return;
    if (index == 0) {
      Navigator.pushNamedAndRemoveUntil(context, '/home', (route) => false);
    } else if (index == 4) {
      Navigator.pushNamed(context, '/cart');
    } else {
      setState(() {
        _selectedIndex = index;
      });
    }
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        automaticallyImplyLeading: false,
        title: const Text("My Orders"),
        leading: const BackButton(),
        actions: const [
          Icon(Icons.search),
          SizedBox(width: 16),
          Icon(Icons.shopping_cart_outlined),
          SizedBox(width: 16),
        ],
        elevation: 0.5,
      ),
      body: Column(
        children: [
          _buildSearchBar(),
          const Divider(),
          Expanded(
            child: ValueListenableBuilder(
              valueListenable: ordersBox.listenable(),
              builder: (context, Box<Product> box, _) {
                if (box.isEmpty) {
                  return const Center(child: Text('No Orders Found'));
                }

                final allOrders = box.values.toList().reversed.toList();
                final filteredOrders = allOrders.where((product) {
                  final name = product.name.toLowerCase();
                  final matchesSearch = name.contains(_searchQuery.toLowerCase());
                  final matchesFilter = _selectedCategory == null ||
                      product.name == _selectedCategory;
                  return matchesSearch && matchesFilter;
                }).toList();

                if (filteredOrders.isEmpty) {
                  return const Center(child: Text('No matching orders'));
                }

                return ListView.builder(
                  itemCount: filteredOrders.length,
                  itemBuilder: (context, index) {
                    final product = filteredOrders[index];
                    return Card(
                      margin: const EdgeInsets.symmetric(horizontal: 12, vertical: 8),
                      child: ListTile(
                        leading: Image.network(
                          product.image,
                          width: 60,
                          fit: BoxFit.cover,
                        ),
                        title: Text(product.name),
                        subtitle: Text('₹ ${product.price.toStringAsFixed(2)}'),
                      ),
                    );
                  },
                );
              },
            ),
          ),
        ],
      ),
      bottomNavigationBar: CustomBottomNavBar(
        currentIndex: _selectedIndex,
        onTap: _onItemTapped,
      ),
    );
  }

  Widget _buildSearchBar() {
    return Padding(
      padding: const EdgeInsets.all(12.0),
      child: Row(
        children: [
          Expanded(
            child: TextField(
              controller: _searchController,
              onChanged: (value) {
                setState(() {
                  _searchQuery = value;
                });
              },
              decoration: InputDecoration(
                hintText: "Search your order here",
                prefixIcon: const Icon(Icons.search),
                border: OutlineInputBorder(
                  borderRadius: BorderRadius.circular(12),
                ),
                contentPadding: const EdgeInsets.symmetric(horizontal: 16),
              ),
            ),
          ),
          const SizedBox(width: 8),
          ElevatedButton.icon(
            onPressed: _showFilterBottomSheet,
            icon: const Icon(Icons.filter_list),
            label: const Text("Filters"),
            style: ElevatedButton.styleFrom(
              padding: const EdgeInsets.symmetric(horizontal: 12, vertical: 12),
              backgroundColor: Colors.grey[200],
              foregroundColor: Colors.black,
            ),
          ),
        ],
      ),
    );
  }

  void _showFilterBottomSheet() async {
    final selected = await showModalBottomSheet<String>(
      context: context,
      builder: (context) {
        return SafeArea(
          child: Column(
            mainAxisSize: MainAxisSize.min,
            children: [
              ListTile(
                title: const Text("All Categories"),
                onTap: () => Navigator.pop(context, null),
              ),
              ListTile(
                title: const Text("Electronics"),
                onTap: () => Navigator.pop(context, "Electronics"),
              ),
              ListTile(
                title: const Text("Grocery"),
                onTap: () => Navigator.pop(context, "Grocery"),
              ),
              ListTile(
                title: const Text("Fashion"),
                onTap: () => Navigator.pop(context, "Fashion"),
              ),
              // Add more categories here if needed
            ],
          ),
        );
      },
    );

    if (_selectedCategory != selected) {
      setState(() {
        _selectedCategory = selected;
      });
    }
  }
}
