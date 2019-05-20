package ru.hse.lupuleac.webtest.objects;

import org.openqa.selenium.WebDriver;

public abstract class PageObject {
    private WebDriver driver;

    PageObject(WebDriver driver) {
        this.driver = driver;
    }
}
