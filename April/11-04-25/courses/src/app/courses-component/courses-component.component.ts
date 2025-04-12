import { Component } from '@angular/core';

@Component({
  selector: 'app-courses-component',
  standalone: false,
  templateUrl: './courses-component.component.html',
  styleUrl: './courses-component.component.css'
})
export class CoursesComponentComponent {
  allCourses = [
    {
      id: 101, name: "Python", author: "Yogesh", duration: 48, price: 0.00, type: 'Free',
      rating: 4.5, image: '/assets/python.png', description: "In this course you will learn basic of python"
    },
    {
      id: 102, name: "Java", author: "Bharat", duration: 45, price: 250.00, type: 'Paid',
      rating: 4.5, image: '/assets/java.png', description: "In this course you will learn basic of core java"
    },
    {
      id: 103, name: "Angular", author: "Rishi", duration: 50, price: 500.00, type: 'Paid',
      rating: 4.5, image: '/assets/angular.jpg', description: "In this course you will learn basic of angular"
    },
    {
      id: 104, name: "React", author: "Mahesh", duration: 30, price: 0.00, type: 'Free',
      rating: 4.5, image: '/assets/react.png', description: "In this course you will learn basic of react"
    },
    {
      id: 105, name: "DotNet", author: "Ram", duration: 40, price: 40.00, type: 'Paid',
      rating: 4.5, image: '/assets/dotnet.png', description: "In this course you will learn basic of dotnet C#"
    },
  ];

  searchText = '';
  search(value:any){
    this.searchText= value
  }

  selectedFilter= 'all';
 
  

  get courses() {
    return this.allCourses.filter(course => {
      const matchesSearch = course.name.toLowerCase().includes(this.searchText.toLowerCase());
      const matchesFilter = this.selectedFilter === 'all' ||
        (this.selectedFilter === 'free' && course.type.toLowerCase() === 'free') ||
        (this.selectedFilter === 'paid' && course.type.toLowerCase() === 'paid');

      return matchesSearch && matchesFilter;
    });
  }

  filterType(type: any) {
    this.selectedFilter = type;
  }
}
