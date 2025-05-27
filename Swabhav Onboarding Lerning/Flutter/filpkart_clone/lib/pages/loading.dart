import 'package:flutter/material.dart';
import 'package:logo_n_spinner/logo_n_spinner.dart';

class Loading extends StatefulWidget {
  const Loading({super.key});

  @override
  State<Loading> createState() => _LoadingState();
}

class _LoadingState extends State<Loading> {
  @override
  void initState() {
    super.initState();
    Future.delayed(const Duration(seconds: 2), () {
      Navigator.pushReplacementNamed(context, '/home');
    });
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
