import { PipeTransform, Pipe } from '@angular/core';

@Pipe({
    name: 'imageformater'
})
export class ImageFormaterPipe implements PipeTransform {
    
    transform(name: string, path: string = '', replace: boolean) {
        let pathAux = 'assets';

        if (path != 'default')
            pathAux += '/' + path;

        if (name.length == 0 && replace) 
            name = 'semCapa.jpg'

        return "/" + pathAux + "/" + name;
    }

}