import { Http, Request, RequestMethod, ResponseContentType, Response, RequestOptions, Headers } from '@angular/http';
import { Router, ActivatedRoute } from '@angular/router';
import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import { NgModule } from '@angular/core';
import { OrganizationChartModule } from 'primeng/primeng';
import { Message, TreeNode } from '../../../../node_modules/primeng/components/common/api';

import { environment } from 'environments/environment';

@Component({
    selector: 'orgchart',
    templateUrl: './orgchart.component.html',
    styles: [`
        .company.ui-organizationchart .ui-organizationchart-node-content.ui-person {
            padding: 0;
            border: 0 none;
        }
        
        .node-header,.node-content {
            padding: .5em .7em;
        }
        
        .node-header {
            background-color: #999;
            color: #ffffff;
            border-top-left-radius:0px;
            border-top-right-radius:0px;
            font-family: 'Open Sans', sans-serif;
        }
        
        .node-content {
            text-align: center;
            border: 1px solid #999;
            font-family: 'Open Sans', sans-serif;
            color:#999;
        }
        
        .node-content img {
            border-radius: 50%;
        }
        
        .ui-organizationchart-node-content.department-cfo {
            background-color: #7247bc;
            color: #ffffff;
        }
        
        .ui-organizationchart-node-content.department-coo {
            background-color: #a534b6;
            color: #ffffff;
        }
        
        .ui-organizationchart-node-content.department-cto {
            background-color: #999;
            color: #ffffff;
            border-radius:0px;
            font-family: 'Open Sans', sans-serif;
        }
        
        .ui-person .ui-node-toggler {
            color: #495ebb !important;
        }
        
        .department-cto .ui-node-toggler {
            color: #999 !important;
            border-top-left-radius:0px;
            border-top-right-radius:0px;
            font-family: 'Open Sans', sans-serif;
            
        }
    `],
    encapsulation: ViewEncapsulation.None
})

export class OrgChartComponent {

    constructor(
        private _http: Http,
        private _router: Router,
        private _route: ActivatedRoute) {
        
        this.ngOnInit();
    }

    data1: TreeNode[];

    data2: TreeNode[];

    selectedNode: TreeNode;

    messages: Message[];

    ngOnInit() {

        this.data1 = [{
            label: 'Geschäftsführer',
            type: 'person',
            styleClass: 'ui-person',
            expanded: true,
            data: { name: 'Max Mustermann', 'Abteilung': 'Geschäftsleitung', 'vcardID': '123' },
            children: [
                {
                    label: 'Personalleitung/Sekretariat GF',
                    type: 'person',
                    styleClass: 'ui-person',
                    expanded: true,
                    data: { name: 'Max Mustermann', 'Abteilung': 'Personalleitung/Sekretariat GF', 'vcardID': '123' }
                },
                {
                    label: 'Leitung Vertrieb, Marketing & Konstruktion Kontaktstifte',
                    type: 'person',
                    styleClass: 'ui-person',
                    expanded: true,
                    data: { name: 'Max Mustermann', 'Abteilung': 'Leitung Vertrieb, Marketing & Konstruktion Kontaktstifte', 'vcardID': '123' }
                },
                {
                    label: 'Leitung Forschung & Entwicklung',
                    type: 'person',
                    styleClass: 'ui-person',
                    expanded: true,
                    data: { name: 'Max Mustermann', 'Abteilung': 'Leitung Forschung & Entwicklung', 'vcardID': '123' }
                }
                
            ]
        }];

        this.data2 = [{
            label: 'Abteilungsleiter',
            type: 'person',
            styleClass: 'ui-person',
            expanded: true,
            data: { name: 'Max Mustermann', 'Abteilung': 'EDV / IT', 'vcardID': '123' },
            children: [
                {
                    label: 'IT Infor Administration',
                    type: 'person',
                    styleClass: 'ui-person',
                    expanded: true,
                    data: { name: 'Martha Musterfrau', 'Abteilung': 'EDV / IT', 'vcardID': '123' }
                },
                {
                    label: 'Systemadministration',
                    type: 'person',
                    styleClass: 'ui-person',
                    expanded: true,
                    data: { name: 'Hans Musterperson', 'Abteilung': 'EDV / IT', 'vcardID': '123' }
                },
                {
                    label: 'Administrator',
                    type: 'person',
                    styleClass: 'ui-person',
                    expanded: true,
                    data: { name: 'Melanie Mustergültig', 'Abteilung': 'EDV / IT', 'vcardID': '123' }
                }
            ]
        }];
    }

    onNodeSelect(event) {
        this.messages = [{ severity: 'success', summary: 'Node Selected', detail: event.node.label }];
    }
}