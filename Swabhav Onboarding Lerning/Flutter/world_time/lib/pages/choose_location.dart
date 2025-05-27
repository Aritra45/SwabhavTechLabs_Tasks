import 'package:flutter/material.dart';
import 'package:world_time/services/world_time.dart';

class ChooseLocation extends StatefulWidget {
  @override
  State<ChooseLocation> createState() => _ChooseLocationState();
}

class _ChooseLocationState extends State<ChooseLocation> {
  WorldTime location = WorldTime();
  bool isLoading = true;

  @override
  void initState() {
    super.initState();
    loadData();
  }

  void loadData() async {
    await location.getTime();
    setState(() {
      isLoading = false;
    });
  }

  void updateName(index)async{
    WorldTime tik = new WorldTime();
    await tik.getTime();
    Navigator.pop(context, {'title': location.cName[index], 'time': tik.time, 'isDayTime':tik.isDayTime});
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: Text('Choose Location'),
        centerTitle: true,
        backgroundColor: Colors.amber[300],
      ),
      body:
          isLoading
              ? Center(child: CircularProgressIndicator())
              : SafeArea(
                child: ListView.builder(
                  itemCount: location.cName.length,
                  itemBuilder: (context, index) {
                    return Card(
                      child: ListTile(
                        onTap: () {
                          updateName(index);
                        },
                        title: Text(location.cName[index]),
                        leading: CircleAvatar(
                          backgroundImage: AssetImage('assets/night.jpeg'),
                        ),
                      ),
                    );
                  },
                ),
              ),
    );
  }
}
