
import {NgModule} from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { PatternListComponent } from './pattern/pattern-list.component';


const routes: Routes = [
        {
            path: 'patternList',
            component: PatternListComponent
    },
        {
            path: 'Pattern/Pattern',
            redirectTo: 'patternList'
        }
    ];


@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]

})


export class AppRoutingModule{}