import 'dart:async' as async;
import 'package:flutter/material.dart';
import 'package:intl/intl.dart';
import 'package:world_time/services/world_time.dart';

class Home extends StatefulWidget {
  @override
  State<Home> createState() => _HomeState();
}

class _HomeState extends State<Home> {
   @override
  void initState() {
    super.initState();
    async.Timer.periodic(Duration(seconds: 1), (timer) async {
      WorldTime tik = WorldTime();
      await tik.getTime();
      setState(() {
        time = DateTime.now();
        
      });
      time2 = DateFormat.jm().format(time);
      print(time);
        print(data['time']);
    });
  }
  DateTime time = DateTime.now();
  String time2= '';
  Map data = {};
  @override
  Widget build(BuildContext context) {
    data = data.isNotEmpty? data : ModalRoute.of(context)?.settings.arguments as Map? ?? {};
    print(data);
    String bgImage = (data['isDayTime'] ?? true) ? 'day.jpeg' : 'night.jpeg';


    return Scaffold(
      
      body: Container(
        decoration: BoxDecoration(
          image: DecorationImage(
            image: AssetImage('assets/$bgImage'),
            fit: BoxFit.cover,
          ),
        ),
        child: SafeArea(
          child: Padding(
            padding: EdgeInsets.fromLTRB(0, 130, 0, 0),
            child: Column(
              crossAxisAlignment: CrossAxisAlignment.center,
              children: [
                OutlinedButton.icon(
                  onPressed: () async{
                    dynamic result = await Navigator.pushNamed(context, '/location');
                    setState(() {
                      data ={
                        'title' : result['title'],
                        'time' : result['time'],
                        'isDayTime' : result['isDayTime']
                      };
                    });
                  },
                  label: Text('Choose Location',style: TextStyle(color: (data['isDayTime'] ?? true) ? Colors.black : Colors.white)),
                  icon: Icon(Icons.edit_location),
                ),
                SizedBox(height: 20),
                Row(
                  mainAxisAlignment: MainAxisAlignment.center,
                  children: [
                    Text(data['title'] ?? 'Unknown', style: TextStyle(fontSize: 20, color: Colors.white)),
                  ],
                ),
                SizedBox(height: 10),
                Row(
                  mainAxisAlignment: MainAxisAlignment.center,
                  children: [
                    Text('$time2', style: TextStyle(fontSize: 50, color: Colors.white)),
                  ],
                ),
              ],
            ),
          ),
        ),
      ),
    );
  }
}
