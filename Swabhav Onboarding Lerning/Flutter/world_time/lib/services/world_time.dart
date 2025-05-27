import 'package:http/http.dart';
import 'package:intl/intl.dart';
import 'dart:convert';

class WorldTime {
  String text;
  List<String> cName;
  String time;
  bool isDayTime;

  WorldTime({
    this.text = '',
    String time = '',
    List<String>? cName,
    this.isDayTime = true,
  }) : this.time = time,
       this.cName = cName ?? [];

  Future<void> getTime() async {
    try {
      Response response = await get(
        Uri.parse('https://jsonplaceholder.typicode.com/users'),
      );

      DateTime samay = DateTime.now();
      time = DateFormat.jm().format(samay);
      isDayTime = samay.hour > 6 && samay.hour < 20 ? true: false;
      List data = jsonDecode(response.body);
      text = data[0]['name'];
      cName = data.map<String>((user) => user['name'].toString()).toList();

      print(cName);
    } catch (e) {
      print('error: $e');
      text = 'could not get the title';
    }
  }
}
