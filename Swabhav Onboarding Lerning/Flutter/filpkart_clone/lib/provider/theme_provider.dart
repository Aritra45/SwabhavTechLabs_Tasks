import 'package:flutter/material.dart';
import 'package:hive/hive.dart';

class ThemeNotifier with ChangeNotifier {
  static const String _boxName = 'settings';
  static const String _key = 'isDarkMode';

  bool _isDark = false;

  bool get isDark => _isDark;

  ThemeMode get currentTheme => _isDark ? ThemeMode.dark : ThemeMode.light;

  ThemeNotifier() {
    _loadTheme(); // Load theme when provider is created
  }

  void _loadTheme() async {
    final box = await Hive.openBox(_boxName);
    _isDark = box.get(_key, defaultValue: false);
    notifyListeners();
  }

  void toggleTheme(bool isOn) async {
    _isDark = isOn;
    final box = await Hive.openBox(_boxName);
    box.put(_key, isOn);
    notifyListeners();
  }
}
