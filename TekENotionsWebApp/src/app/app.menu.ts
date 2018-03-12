import { MenuItem } from './fw/services/menu.service';

export let initialMenuItems: Array<MenuItem> = [
    {
        text: 'Dashboard',
        icon: 'glyphicon-dashboard',
        route: '/dashboard',
        submenu: null
    },
    
    {
        text: 'Settings',
        icon: 'glyphicon-wrench',
        route: '/settings',
        submenu: null
    }
];