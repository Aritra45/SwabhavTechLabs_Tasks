import 'package:flutter/material.dart';

class ThemeNotifier with ChangeNotifier {
  bool _isDark = false;

  bool get isDark => _isDark;

  ThemeMode get currentTheme => _isDark ? ThemeMode.dark : ThemeMode.light;

  void toggleTheme(bool isOn) {
    _isDark = isOn;
    notifyListeners();
  }
}
