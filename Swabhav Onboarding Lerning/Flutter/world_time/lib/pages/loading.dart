import 'package:flutter/material.dart';
import 'package:http/http.dart';
import 'dart:convert';

class Loading extends StatefulWidget {

  @override
  State<Loading> createState() => _LoadingState();
}

class _LoadingState extends State<Loading> {

  void getTime() async{
    Response response = await get(Uri.parse('https://jsonplaceholder.typicode.com/posts/1'));
    Map data = jsonDecode(response.body);
    print(data);
  }

  @override
  void initState(){
    super.initState();
    getTime();
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      
    );
  }
}