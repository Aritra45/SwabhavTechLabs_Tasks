import { Directive, ElementRef, Renderer2 } from '@angular/core';

@Directive({
  selector: '[appCustomDirectives]',
  standalone: false
})
export class CustomDirectivesDirective {

  constructor(private element:ElementRef, private renderer:Renderer2) {

   }
   ngOnInit(){
    // this.element.nativeElement.style.backgroundColor="red"
    this.renderer.setStyle(this.element.nativeElement, 'color' , 'red')
    this.renderer.addClass(this.element.nativeElement, 'content')
   }

}
