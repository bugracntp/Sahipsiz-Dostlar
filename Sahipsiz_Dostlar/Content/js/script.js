"use strict";

/**
 * Navbar toggle
 */

const navbarOpen = document.querySelector('[data-nav-open-btn]');
const navbarClose = document.querySelector('[data-nav-close-btn]');
const navbar = document.querySelector('[data-navbar]');
const navElements = [navbarOpen, navbarClose];
navElements.forEach(element => {
    element.addEventListener('click', () => {
        navbar.classList.toggle('active');
    });
});

/** 
 * Navbar close on click links
 */

const navbarLinks = document.querySelectorAll('[data-nav-link]');
navbarLinks.forEach(link => {
    link.addEventListener('click', () => {
        navbar.classList.remove('active');
    });
});

/**
 * Navbar activate on scroll
 */

const header = document.querySelector('[data-header]');
const dataNavLinks = document.querySelectorAll('[data-nav-link]');
window.addEventListener('scroll', () => {
    window.scrollY >= 50 ? header.classList.add('active') : header.classList.remove('active');
    window.scrollY >= 50 ? dataNavLinks.classList.add('active') : dataNavLinks.classList.remove('active');
});
