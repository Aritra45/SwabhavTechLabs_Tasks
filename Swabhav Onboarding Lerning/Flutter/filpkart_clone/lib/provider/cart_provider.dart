import 'package:flutter/material.dart';

class CartProvider with ChangeNotifier {
  final Map<int, int> _quantities = {};
  final Map<int, bool> _selected = {};

  int getQuantity(int index) => _quantities[index] ?? 1;
  bool isSelected(int index) => _selected[index] ?? false;

  void increaseQuantity(int index) {
    _quantities[index] = getQuantity(index) + 1;
    notifyListeners();
  }

  void decreaseQuantity(int index) {
    if (getQuantity(index) > 1) {
      _quantities[index] = getQuantity(index) - 1;
      notifyListeners();
    }
  }

  void toggleSelection(int index) {
    _selected[index] = !isSelected(index);
    notifyListeners();
  }

  double getTotalPrice(List products) {
    double total = 0.0;
    for (int i = 0; i < products.length; i++) {
      if (isSelected(i)) {
        total += products[i].price * getQuantity(i);
      }
    }
    return total;
  }

  void clearSelections() {
    _selected.clear();
    _quantities.clear();
    notifyListeners();
  }
}
