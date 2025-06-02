import 'package:filpkart_clone/provider/theme_provider.dart';
import 'package:flutter/material.dart';
import 'package:provider/provider.dart';
import 'package:reactive_forms/reactive_forms.dart';
import 'package:fluttertoast/fluttertoast.dart';
import 'package:hive/hive.dart';
import 'showPassword.dart';

class FlipkartAuthPage extends StatefulWidget {
  const FlipkartAuthPage({super.key});

  @override
  _FlipkartAuthPageState createState() => _FlipkartAuthPageState();
}

class _FlipkartAuthPageState extends State<FlipkartAuthPage>
    with SingleTickerProviderStateMixin {
  late TabController _tabController;
  final FormGroup loginForm = FormGroup({
    'email': FormControl<String>(
      validators: [Validators.required, Validators.email],
    ),
    'password': FormControl<String>(
      validators: [Validators.required, Validators.minLength(6)],
    ),
    'rememberMe': FormControl<bool>(value: false),
  });

  final FormGroup registerForm = FormGroup({
    'name': FormControl<String>(validators: [Validators.required]),
    'email': FormControl<String>(
      validators: [Validators.required, Validators.email],
    ),
    'password': FormControl<String>(
      validators: [Validators.required, Validators.minLength(6)],
    ),
  });

  @override
  void initState() {
    super.initState();
    _tabController = TabController(length: 2, vsync: this);
    _prefillRememberedUser();
  }

  void _prefillRememberedUser() async {
    final userBox = Hive.box('users');
    final rememberedEmail = userBox.get('rememberedUser');

    if (rememberedEmail != null) {
      final rememberedUser = userBox.get(rememberedEmail);
      if (rememberedUser != null) {
        loginForm.control('email').value = rememberedEmail;
        loginForm.control('password').value = rememberedUser['password'];
        loginForm.control('rememberMe').value = true;
      }
    }
  }

  void _login() async {
    if (loginForm.valid) {
      final email = loginForm.control('email').value as String;
      final password = loginForm.control('password').value as String;
      // final rememberMe = loginForm.control('rememberMe').value as bool;
      final userBox = Hive.box('users');
      final storedUser = userBox.get(email);

      if (storedUser != null && storedUser['password'] == password) {
        Navigator.pushReplacementNamed(context, '/');

        userBox.put('loggedUser', email);

        Fluttertoast.showToast(
          msg: 'Login successful',
          backgroundColor: Colors.green,
          textColor: Colors.white,
        );
      } else {
        Fluttertoast.showToast(
          msg: 'Invalid credentials',
          backgroundColor: Colors.red,
          textColor: Colors.white,
        );
      }
    } else {
      loginForm.markAllAsTouched();
    }
  }

  bool _isRegistering = false;
  void _register() async {
    if (registerForm.valid) {
      setState(() {
        _isRegistering = true;
      });

      final name = registerForm.control('name').value as String;
      final email = registerForm.control('email').value as String;
      final password = registerForm.control('password').value as String;

      final userBox = Hive.box('users');
      final existingUser = userBox.get(email);

      await Future.delayed(const Duration(seconds: 1));

      if (existingUser == null) {
        await userBox.put(email, {
          'name': name,
          'email': email,
          'password': password,
        });

        Fluttertoast.showToast(
          msg: 'Registration successful, Please Login',
          backgroundColor: Colors.green,
          textColor: Colors.white,
        );
        Navigator.pushReplacementNamed(context, '/login');
      } else {
        Fluttertoast.showToast(
          msg: 'User already exists',
          backgroundColor: Colors.red,
          textColor: Colors.white,
        );
      }

      setState(() {
        _isRegistering = false;
      });
    } else {
      registerForm.markAllAsTouched();
    }
  }

  Widget buildTextField(
    String label,
    String controlName, {
    bool obscure = false,
  }) {
    if (obscure) {
      return PasswordReactiveTextField(label: label, controlName: controlName);
    }

    return ReactiveTextField<String>(
      formControlName: controlName,
      decoration: InputDecoration(
        labelText: label,
        border: const OutlineInputBorder(),
        errorStyle: const TextStyle(color: Colors.redAccent),
      ),
      validationMessages: {
        ValidationMessage.required: (_) => '$label is required',
        ValidationMessage.email: (_) => 'Invalid email',
        ValidationMessage.minLength: (_) => '$label too short',
      },
    );
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        backgroundColor: Colors.amber,
        bottom: TabBar(
          controller: _tabController,
          labelColor: Colors.blue[900],
          unselectedLabelColor: Colors.black,
          tabs: const [Tab(text: 'Login'), Tab(text: 'Register')],
        ),
      ),

      body: SafeArea(
        child: TabBarView(
          controller: _tabController,
          children: [
            /// Login Tab
            Padding(
              padding: const EdgeInsets.all(16.0),
              child: ReactiveForm(
                formGroup: loginForm,
                child: SingleChildScrollView(
                  child: Column(
                    mainAxisAlignment: MainAxisAlignment.center,
                    children: [
                      Consumer<ThemeNotifier>(
                        builder: (context, themeNotifier, child) {
                          return Image.asset(
                            themeNotifier.isDark
                                ? 'assets/banner-dark.png'
                                : 'assets/banner.png',
                            height: 100,
                            width: 200,
                          );
                        },
                      ),

                      const SizedBox(height: 16),
                      buildTextField('Email', 'email'),
                      const SizedBox(height: 16),
                      buildTextField('Password', 'password', obscure: true),
                      const SizedBox(height: 16),
                      ReactiveCheckboxListTile(
                        formControlName: 'rememberMe',
                        title: const Text('Remember Me'),
                        controlAffinity: ListTileControlAffinity.leading,
                      ),
                      const SizedBox(height: 24),
                      ElevatedButton(
                        onPressed: _login,
                        child: const Text(
                          'Login',
                          style: TextStyle(color: Colors.black),
                        ),
                        style: ElevatedButton.styleFrom(
                          backgroundColor: Colors.amber,
                        ),
                      ),
                    ],
                  ),
                ),
              ),
            ),

            /// Register Tab
            _isRegistering
                ? Center(child: CircularProgressIndicator())
                : Padding(
                  padding: const EdgeInsets.all(16.0),
                  child: ReactiveForm(
                    formGroup: registerForm,
                    child: SingleChildScrollView(
                      child: Column(
                        mainAxisAlignment: MainAxisAlignment.center,
                        children: [
                          Consumer<ThemeNotifier>(
                            builder: (context, themeNotifier, child) {
                              return Image.asset(
                                themeNotifier.isDark
                                    ? 'assets/banner-dark.png'
                                    : 'assets/banner.png',
                                height: 100,
                                width: 200,
                              );
                            },
                          ),
                          const SizedBox(height: 16),
                          buildTextField('Full Name', 'name'),
                          const SizedBox(height: 16),
                          buildTextField('Email', 'email'),
                          const SizedBox(height: 16),
                          buildTextField('Password', 'password', obscure: true),
                          const SizedBox(height: 24),
                          ElevatedButton(
                            onPressed: _register,
                            child: const Text(
                              'Register',
                              style: TextStyle(color: Colors.black),
                            ),
                            style: ElevatedButton.styleFrom(
                              backgroundColor: Colors.amber,
                            ),
                          ),
                        ],
                      ),
                    ),
                  ),
                ),
          ],
        ),
      ),
    );
  }
}
