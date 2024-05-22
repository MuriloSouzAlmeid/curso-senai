describe('Fluxo do Usuário na Aplicação de Música', () => {
  before('passes', () => {
    cy.visit('/')
  })

  it("Visualizar playlists e executar uma música", () => {
    // Then eu vejo o header "Good morning"
    cy.get("[aria-label='title-head']").should("contain", "Good morning")
    cy.wait(1000)
    
    // And eu vejo uma lista de playlists
    cy.get("[aria-label='playlist-item']").should("have.length.greaterThan", 0)

    // When eu clico na primeira playlist
    cy.get("[aria-label='playlist-item']").first().click()
    cy.wait(1000)

    // Then eu vejo uma lista de músicas
    cy.get("[aria-label='music-item']").should("have.length.greaterThan", 0)

    // And eu clico na primeira música - Then a música começa a tocar
    cy.get("[aria-label='music-item']").first().click()

  })


  it("Navegar entre playlists e executar outra música", () => {
    // When eu volto para a listagem de playlists
    cy.get("[aria-label='return-button']").click()
    cy.wait(1000)

    // And eu clico na segunda playlist
    cy.get("[aria-label='playlist-item']").eq(1).click()
    cy.wait(1000)

    // Then eu vejo uma lista de músicas
    cy.get("[aria-label='music-item']").should("have.length.greaterThan", 0)

    // And eu clico na primeira música - Then a música começa a tocar
    cy.get("[aria-label='music-item']").first().click()
 
  })


  it("Procurar e favoritar uma música", () => {
    // Given que eu estou na tela de Pesquisa
    cy.get("[href='/Search']").click()
    cy.wait(1000)

    // When eu procuro por uma música "Nome da Música"
    cy.get("[data-testid='campoBusca']").type("Cupid")
    cy.wait(2000)

    // Then eu vejo uma lista de resultados de músicas
    cy.get("[aria-label='music-item-sch']").should("have.length.greaterThan", 0)

    // When eu clico na primeira música dos resultados - Then a música começa a tocar
    // cy.get("[aria-label='music-item']").eq(0).click()

    let musicaPesquisada;

    musicaPesquisada = cy.get("[aria-label='music-item-sch']").contains('Cupid').click()
    cy.wait(4000)

    // And eu clico para favoritar a música - Then a música é adicionada à lista de favoritos
    cy.get(musicaPesquisada).get("[data-testid='icon-button-sch']").eq(0).click()

  })


  it("Verificar música favoritada na tela de Favoritos", () => {
    // Given que eu estou na tela de Favoritos
    cy.get("[href='/Favorites']").click()
    cy.wait(1000)

    // Then eu vejo uma lista de músicas favoritas
    cy.get("[aria-label='music-item-fav']").should("have.length.greaterThan", 0)

    // And eu vejo a música favoritada na lista
    let musicaFavoritada;

    musicaFavoritada = cy.get("[aria-label='music-item-fav']").first()

    // When eu clico na música favoritada - Then a música começa a tocar
    musicaFavoritada.click()
  })

})