import 'package:flutter/material.dart';
import 'package:logo_n_spinner/logo_n_spinner.dart';
import 'package:hive/hive.dart';

class Loading extends StatefulWidget {
  const Loading({super.key});

  @override
  State<Loading> createState() => _LoadingState();
}

class _LoadingState extends State<Loading> {
  @override
  void initState() {
    super.initState();
    checkLoginStatus();
  }

  Future<void> checkLoginStatus() async {
    await Future.delayed(const Duration(seconds: 2));

    final userBox = await Hive.openBox('users');
    final rememberedEmail = userBox.get('loggedUser');

    if (rememberedEmail != null) {
      final user = userBox.get(rememberedEmail);
      if (user != null && user['password'] != null) {
        Navigator.pushReplacementNamed(context, '/home');
        return;
      }
    }

    Navigator.pushReplacementNamed(context, '/login');
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      body: SafeArea(
        child: Center(
          child: LogoandSpinner(
            imageAssets: 'assets/loading.png',
            reverse: true,
            arcColor: Colors.blue,
            spinSpeed: const Duration(milliseconds: 500),
          ),
        ),
      ),
    );
  }
}
