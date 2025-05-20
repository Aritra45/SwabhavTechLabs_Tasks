import 'package:flutter/material.dart';
import 'info.dart';
import 'detailsCard.dart';

void main() => runApp(MaterialApp(home: Home()));

class Home extends StatefulWidget {
  @override
  State<Home> createState() => _HomeState();
}

class _HomeState extends State<Home> {
  int tea = 0;
  bool isShow = false;

  List<Info> infos = [
    Info(
      '“We cannot solve problems with the kind of thinking we employed when we came up with them.” — Albert Einstein',
    ),
    Info(
      '“When you give joy to other people, you get more joy in return. You should give a good thought to the happiness that you can give out.” —Eleanor Roosevelt',
    ),
    Info(
      '“Nature has given us all the pieces required to achieve exceptional wellness and health, but has left it to us to put these pieces together.” —Diane McLaren',
    ),
  ];

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      backgroundColor: Colors.grey[800],
      appBar: AppBar(
        title: Text(
          'Aritra ID Card',
          style: TextStyle(color: Colors.white, fontWeight: FontWeight.bold),
        ),
        backgroundColor: Colors.grey[600],
        centerTitle: true,
      ),
      body: SingleChildScrollView(
        scrollDirection: Axis.vertical,
        child: Padding(
          padding: EdgeInsets.fromLTRB(20.0, 20.0, 20, 80),
          child: Column(
            crossAxisAlignment: CrossAxisAlignment.start,
            children: [
              Center(
                child: CircleAvatar(
                  backgroundImage: AssetImage('asstes/pro.png'),
                  radius: 50.0,
                ),
              ),
              Divider(height: 60, color: Colors.grey[600]),

              Text(
                'Name',
                style: TextStyle(color: Colors.white, letterSpacing: 5.0),
              ),
              Text(
                'Aritra Deb',
                style: TextStyle(
                  color: Colors.amberAccent,
                  letterSpacing: 5.0,
                  fontSize: 20.0,
                  fontWeight: FontWeight.bold,
                ),
              ),

              SizedBox(height: 20),
              Text(
                'Job Role',
                style: TextStyle(color: Colors.white, letterSpacing: 5.0),
              ),
              Text(
                'FullStack Developer',
                style: TextStyle(
                  color: Colors.amberAccent,
                  letterSpacing: 5.0,
                  fontSize: 20.0,
                  fontWeight: FontWeight.bold,
                ),
              ),
              SizedBox(height: 20),
              Row(
                mainAxisAlignment: MainAxisAlignment.start,
                children: [
                  Icon(Icons.email, color: Colors.white),
                  Padding(
                    padding: EdgeInsets.only(left: 10),
                    child: Text(
                      'aritradeb45@gmail.com',
                      style: TextStyle(color: Colors.white),
                    ),
                  ),
                ],
              ),
              SizedBox(height: 20),
              Row(
                mainAxisAlignment: MainAxisAlignment.start,
                children: [
                  Icon(Icons.call, color: Colors.white),
                  Padding(
                    padding: EdgeInsets.only(left: 10),
                    child: Text(
                      '7044373952',
                      style: TextStyle(color: Colors.white),
                    ),
                  ),
                ],
              ),
              SizedBox(height: 20),
              Row(
                mainAxisAlignment: MainAxisAlignment.start,
                children: [
                  Icon(Icons.coffee, color: Colors.white),
                  Padding(
                    padding: EdgeInsets.only(left: 10),
                    child: Text(
                      '$tea',
                      style: TextStyle(color: Colors.yellow, fontSize: 30),
                    ),
                  ),
                ],
              ),
              Center(
                child: OutlinedButton(
                  onPressed: () {
                    setState(() {
                      isShow = !isShow;
                    });
                  },
                  child: Text(
                    isShow ? 'Show Less' : 'Show More',
                    style: TextStyle(color: Colors.white),
                  ),
                ),
              ),
              if (isShow)
                Center(
                  child: Column(
                    children:
                        infos
                            .map(
                              (info) => cardDetails(
                                info,
                                deleteCard: () {
                                  setState(() {
                                    infos.remove(info);
                                  });
                                },
                              ),
                            )
                            .toList(),
                  ),
                ),
            ],
          ),
        ),
      ),
      floatingActionButton: FloatingActionButton(
        onPressed: () {
          setState(() {
            tea += 1;
          });
        },
        child: Icon(Icons.add),
        backgroundColor: const Color.fromARGB(255, 246, 174, 239),
      ),
    );
  }
}
