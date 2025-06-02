import 'package:flutter/material.dart';
import 'package:reactive_forms/reactive_forms.dart';

class PasswordReactiveTextField extends StatefulWidget {
  final String label;
  final String controlName;

  const PasswordReactiveTextField({
    super.key,
    required this.label,
    required this.controlName,
  });

  @override
  State<PasswordReactiveTextField> createState() =>
      _PasswordReactiveTextFieldState();
}

class _PasswordReactiveTextFieldState extends State<PasswordReactiveTextField> {
  bool _obscureText = true;

  @override
  Widget build(BuildContext context) {
    return ReactiveTextField<String>(
      formControlName: widget.controlName,
      obscureText: _obscureText,
      decoration: InputDecoration(
        labelText: widget.label,
        border: const OutlineInputBorder(),
        errorStyle: const TextStyle(color: Colors.redAccent),
        suffixIcon: IconButton(
          icon: Icon(
            _obscureText ? Icons.visibility_off : Icons.visibility,
          ),
          onPressed: () {
            setState(() {
              _obscureText = !_obscureText;
            });
          },
        ),
      ),
      validationMessages: {
        ValidationMessage.required: (_) => '${widget.label} is required',
        ValidationMessage.email: (_) => 'Invalid email',
        ValidationMessage.minLength: (_) => '${widget.label} too short',
      },
    );
  }
}
