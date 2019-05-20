package ru.hse.lupuleac.webtest.elements;

import org.openqa.selenium.By;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.WebElement;
public abstract class PageElement {
    protected WebDriver webDriver;
    protected WebElement webElement;

    public PageElement(WebDriver driver, By by) {
        webDriver = driver;
        webElement = driver.findElement(by);
    }
}
