import 'package:flutter/material.dart';

void main() => runApp(MaterialApp(home: Home()));

class Home extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: Text('AD Banking App', style: TextStyle(color: Colors.white)),
        centerTitle: true,
        backgroundColor: Colors.red[600],
      ),
      body: 
      Stack(
        children: [
          Positioned.fill(
            child: Image(
              image: AssetImage('assets/bg.jpg'), 
              fit: BoxFit.cover,
            ),
          ),
      Column(
        crossAxisAlignment: CrossAxisAlignment.stretch,
        children: [
          Padding(
            padding: EdgeInsets.all(10.0),
            child: Row(
              mainAxisAlignment: MainAxisAlignment.end,
              children: [
                OutlinedButton(
                  onPressed: () {},
                  child: Text('Home'),
                  style: OutlinedButton.styleFrom(
                    backgroundColor: Colors.amber,
                    foregroundColor: Colors.black,
                  ),
                ),
                SizedBox(width: 8),
                OutlinedButton(
                  onPressed: () {},
                  child: Text('Contact'),
                  style: OutlinedButton.styleFrom(
                    backgroundColor: Colors.amber,
                    foregroundColor: Colors.black,
                  ),
                ),
                SizedBox(width: 8),
                OutlinedButton(
                  onPressed: () {},
                  child: Text('About'),
                  style: OutlinedButton.styleFrom(
                    backgroundColor: Colors.amber,
                    foregroundColor: Colors.black,
                  ),
                ),
              ],
            ),
          ),
          SizedBox(height: 20),
          Row(
            mainAxisAlignment: MainAxisAlignment.center,

            children: [
              Container(
                padding: EdgeInsets.all(16),
                color: Colors.grey,
                width: 300,
                child: Column(
                  crossAxisAlignment: CrossAxisAlignment.start,
                  children: [
                    Text(
                      'Login Form',
                      style: TextStyle(color: Colors.white, fontSize: 18),
                    ),
                    SizedBox(height: 10),
                    TextField(
                      keyboardType: TextInputType.emailAddress,
                      decoration: InputDecoration(
                        border: OutlineInputBorder(),
                        labelText: 'Enter your email',
                      ),
                    ),
                    SizedBox(height: 10),
                    TextField(
                      decoration: InputDecoration(
                        border: OutlineInputBorder(),
                        labelText: 'Enter your password',
                      ),
                    ),
                    SizedBox(height: 10),
                    Container(
                      margin: EdgeInsets.fromLTRB(199.0, 0.0, 0.0, 0.0),
                      child: TextButton(
                        onPressed: () {
                          print('submitted');
                        },
                        child: Text(
                          'Submit',
                          style: TextStyle(color: Colors.white),
                        ),
                        style: TextButton.styleFrom(
                          backgroundColor: Colors.blue,
                        ),
                      ),
                    ),
                  ],
                ),
              ),
            ],
          ),
        ],
      ),
        ]
      ),
      floatingActionButton: FloatingActionButton(
        onPressed: () {
          // Add your action here
        },
        child: Text('click', style: TextStyle(color: Colors.white)),
        backgroundColor: Colors.red[600],
        hoverColor: Colors.blue,
      ),
    );
  }
}
